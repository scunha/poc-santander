using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using Juntos.SomosMais.Challenge.Domain.Interfaces.Services;
using System.Net;
using Juntos.SomosMais.Challenge.Domain.Consts;
using Newtonsoft.Json;


namespace Juntos.SomosMais.Challenge.Service.Services
{
    public class HelperService : IHelperService
    {
        public List<T> ReadCsvByStream<T>(Stream file)
        {
            try
            {
                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Encoding = Encoding.UTF8,
                    Delimiter = ","
                };
                using var textReader = new StreamReader(file, Encoding.UTF8);
                using var csv = new CsvReader(textReader, configuration);
                var records = csv.GetRecords<T>();

                return records.ToList();
            }catch (Exception ex)
            {
                throw new Exception($"{nameof(HelperService)} - {ErrorConsts.ERROR_READ_CSV_STREAM}", ex);
            }
        }

        public T ReadJsonByStream<T>(Stream file)
        {
            try
            {
                var serializer = new JsonSerializer();
                

                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Encoding = Encoding.UTF8,
                    Delimiter = ","
                };
                

                using var textReader = new StreamReader(file);
                var json = textReader.ReadToEnd();

                
                var root = JsonConvert.DeserializeObject<T>(json);
                               

                return root ?? throw new Exception($"{nameof(HelperService)} - {ErrorConsts.ERROR_READ_CSV_STREAM}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(HelperService)} - {ErrorConsts.ERROR_READ_CSV_STREAM}", ex);
            }
        }

        public Stream ReadByPathUrl(string url)
        {
            try
            {
                var uri = new Uri(url);

                using WebClient cliente = new WebClient();
                var bytes = cliente.OpenRead(uri);

                return bytes;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(HelperService)} - {ErrorConsts.ERROR_READ_PATCH_URL}", ex);
            }
        }

        
    }
}
