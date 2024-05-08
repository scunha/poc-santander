using Juntos.SomosMais.Challenge.Domain.Interfaces.Services;
using Juntos.SomosMais.Challenge.Domain.Consts;
using Juntos.SomosMais.Challenge.Domain.Models.Request.Csv;
using Juntos.SomosMais.Challenge.Domain.Models.Request.Json;
using Juntos.SomosMais.Challenge.Domain.Models.Response;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Juntos.SomosMais.Challenge.Domain.Models.Assistant;
using Google.Protobuf;
using AutoMapper;

namespace Juntos.SomosMais.Challenge.Service.Services
{
    public class ChallengeService(IHelperService helperService, ILogger<ChallengeService> logger) : IChallengeService
    {

        private readonly ConcurrentDictionary<int, RootResponseModel> _rootResponseModel = new ConcurrentDictionary<int, RootResponseModel>();
        private int cont = 1;

        public async Task<bool> InitialLoad(string urlCsv, string urlJson)
        {
            bool result = await ReadArquivoCsvCloud(urlCsv);

            result = await ReadArquivojsonCloud(urlJson);

            return result;
        }

        public ConcurrentDictionary<int, RootResponseModel> obterRootSnapshot() => _rootResponseModel;

        public ResultResponseModel GetListPagination (string region, string type, int pageNumber, int pageSize)
        {

            var listRoot = obterRootSnapshot();

            var listValues = listRoot.Values.ToList();

            var filter = listValues.Where(x => x.Type.ToUpper() == type.ToUpper() &&
                                            x.Location.Region.ToUpper() == region.ToUpper()).ToList();
            
            
            
            
            var resultFilter = filter.Skip(pageNumber * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            var totalPages = (int)Math.Ceiling(filter.Count / (double)pageSize);

            var result = new ResultResponseModel 
            {   PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPage = totalPages,
                Users = resultFilter 
            };

            return result;
        }

        private async Task<bool> ReadArquivoCsvCloud(string url)
        {
            var result = false;

            logger.LogInformation($"iniciando rotina de carga");
            var resultRead = helperService.ReadByPathUrl(url);

            if (resultRead == null)
            {
                logger.LogInformation($"iniciando rotina de carga");
                throw new Exception(ErrorConsts.INVALID_DOCUMENT_CSV);
            }

            var resultTransform = helperService.ReadCsvByStream<ExcelRequestModel>(resultRead);

            var mapperResponse = await MapperCsvRequestToReposnse(resultTransform);

            if (InsertConcurrentDictionary(mapperResponse.ToList()))
            {
                result = true;
            }
            

            return result;
        }

        private async Task<bool> ReadArquivojsonCloud(string url)
        {
            var result = false;

            logger.LogInformation($"iniciando rotina de carga");
            var resultRead = helperService.ReadByPathUrl(url);

            if (resultRead == null)
            {
                logger.LogInformation($"iniciando rotina de carga");
                throw new Exception(ErrorConsts.INVALID_DOCUMENT_CSV);
            }

            var resultTransform = helperService.ReadJsonByStream<RootRequestModel>(resultRead);

            var mapperResponse = await MapperJsonRequestToReposnse(resultTransform);

            if (InsertConcurrentDictionary(mapperResponse.ToList()))
            {
                result = true;
            }

            return result;
        }

        private async Task<IEnumerable<RootResponseModel>> MapperCsvRequestToReposnse(IEnumerable<ExcelRequestModel> excelRequestModel)
        {
            var result = new List<RootResponseModel>();

            foreach(var excel in excelRequestModel)
            {
                var rootResponseModel = new RootResponseModel
                {
                    Type = GetLocationClassification(excel.location__coordinates__latitude, excel.location__coordinates__longitude),
                    Gender = FormatGender(excel.gender),
                    Name = new NameResponseModel
                    {
                        Title = excel.name__title,
                        First = excel.name__first,
                        Last = excel.name__last
                    },
                    Location = new LocationResponseModel
                    {
                        Region = GetRegionByEstate(excel.location__state),
                        Street = excel.location__street,
                        City = excel.location__city,
                        State = excel.location__state,
                        Postcode = excel.location__postcode,
                        Coordinates = new CoordinatesResponseModel
                        {
                            Latitude = excel.location__coordinates__latitude.ToString(),
                            Longitude = excel.location__coordinates__longitude.ToString()
                        },
                        Timezone = new TimezoneResponseModel
                        {
                            Offset = excel.location__timezone__offset.ToString(),
                            Description = excel.location__timezone__description
                        }
                    },
                    Email = excel.email,
                    Birthday = excel.dob__date,
                    Registered = excel.registered__date,
                    TelephoneNumbers = new List<string>{FormatPhone(excel.phone)},
                    MobileNumbers = new List<string> {FormatPhone(excel.cell)},
                    Picture = new PictureresponseModel
                    {
                        Large = excel.picture__large,
                        Medium = excel.picture__medium,
                        Thumbnail = excel.picture__thumbnail,
                    },
                    Nationality = "BR"
                };

                result.Add(rootResponseModel);
            }

            return result;
        }

        private async Task<IEnumerable<RootResponseModel>> MapperJsonRequestToReposnse(RootRequestModel rootRequestModel)
        {
            var result = new List<RootResponseModel>();

            foreach (var root in rootRequestModel.Results)
            {
                var rootResponseModel = new RootResponseModel
                {
                    Type = GetLocationClassification(double.Parse(root.Location.Coordinates.Latitude), double.Parse(root.Location.Coordinates.Longitude)),
                    Gender = FormatGender(root.Gender) ,
                    Name = new NameResponseModel
                    {
                        Title = root.Name.Title,
                        First = root.Name.First,
                        Last = root.Name.Last
                    },
                    Location = new LocationResponseModel
                    {
                        Region = GetRegionByEstate(root.Location.State),
                        Street = root.Location.Street,
                        City = root.Location.City,
                        State = root.Location.State,
                        Postcode = root.Location.Postcode,
                        Coordinates = new CoordinatesResponseModel
                        {
                            Latitude = root.Location.Coordinates.Latitude.ToString(),
                            Longitude = root.Location.Coordinates.Longitude.ToString()
                        },
                        Timezone = new TimezoneResponseModel
                        {
                            Offset = root.Location.Timezone.Offset.ToString(),
                            Description = root.Location.Timezone.Description
                        }
                    },
                    Email = root.Email,
                    Birthday = root.Dob.Date,
                    Registered = root.Registered.Date,
                    TelephoneNumbers = new List<string> { FormatPhone(root.Phone) },
                    MobileNumbers = new List<string> { FormatPhone(root.Cell) },
                    Picture = new PictureresponseModel
                    {
                        Large = root.Picture.Large,
                        Medium = root.Picture.Medium,
                        Thumbnail = root.Picture.Thumbnail,
                    },
                    Nationality = "BR"
                };

                result.Add(rootResponseModel);
            }

            return result;
        }

        private string FormatPhone (string  phone) => $"+55{phone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-","")}";

        private string FormatGender(string gender) => gender.ToLower().Trim() == "female" ? "F" : gender.ToLower().Trim() == "male" ? "M" : string.Empty;
        private  bool InsertConcurrentDictionary(List<RootResponseModel> rootResponseModel)
        {
            bool sucesso = true;
            

            foreach (var item in rootResponseModel)
            {
                if (!_rootResponseModel.TryAdd(cont, item))
                {
                    logger.LogError($"Falha ao inserir registro, {item.Name.First} {item.Name.First}");
                    return false;
                }
                cont++;
            }
            logger.LogInformation($"Total de registros: {_rootResponseModel.Count}");

            return sucesso;
        }

        private string GetLocationClassification(double latitude, double longitude )
        {

            var result = "LABORIOUS";

            var classification = new ClassificationCoordinatesModel();
           
            if ((latitude >= classification.MinLatEsp1 && latitude <= classification.MaxLatEsp1) &&
                (longitude >= classification.MinLonEsp1 && longitude <= classification.MaxLonEsp1))
                result = "ESPECIAL";
            else if ((latitude >= classification.MinLatEsp2 && latitude <= classification.MaxLatEsp2) &&
                (longitude >= classification.MinLonEsp2 && longitude <= classification.MaxLonEsp2))
                result = "ESPECIAL";
            else if ((latitude >= classification.MinLatNormal && latitude <= classification.MaxLatNormal) &&
                (longitude >= classification.MinLonNormal && longitude <= classification.MaxLonNormal))
                result = "NORMAL";

            return result;
        }

        private string GetRegionByEstate(string state)
        {
            var result = "REGIÃO NÃO ENCONTRADA";

            var centroOeste = new List<string> { "DISTRITO FEDERAL", "GOIÁS", "MATO GROSSO", "MATO GROSSO DO SUL" };
            var nordeste = new List<string> { "ALAGOAS", "BAHIA", "CEARÁ", "MARANHÃO", "PARAÍBA", "PERNAMBUCO", "PIAUÍ", "RIO GRANDE DO NORTE", "SERGIPE" };
            var norte = new List<string> { "ACRE", "AMAPÁ", "AMAZONAS", "PARÁ", "RONDÔNIA", "RORAIAMA", "TOCATINS" };
            var sudeste = new List<string> { "SÃO PAULO", "MINAS GERAIS", "RIO DE JANEIRO", "ESPÍRITO SANTO" };
            var sul = new List<string> { "PARANÁ", "RIO GRANDE DO SUL", "SANTA CATARINA" };

            if (centroOeste.Contains(state.ToUpper().Trim()))
                result = "Centro-Oeste";
            if (nordeste.Contains(state.ToUpper().Trim()))
                result = "Nordeste";
            if (norte.Contains(state.ToUpper().Trim()))
                result = "Norte";
            if (sudeste.Contains(state.ToUpper().Trim()))
                result = "Sudeste";
            if (sul.Contains(state.ToUpper().Trim()))
                result = "Sul";

            return result;
        }
    }
}
