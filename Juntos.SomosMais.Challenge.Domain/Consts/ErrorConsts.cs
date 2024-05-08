using System.ComponentModel;

namespace Juntos.SomosMais.Challenge.Domain.Consts;
public static class ErrorConsts
{
    public const string INVALID_DOCUMENT_CSV = "Arquivo CSV inválido!";
    public const string ERROR_READ_CSV_STREAM = "Erro ao fazer leitura e conversão do arquivo!";
    public const string ERROR_READ_PATCH_URL = "Erro ao ler arquivo no storage!";
}