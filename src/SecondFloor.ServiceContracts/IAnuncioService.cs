using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.DataContracts.Messages.Anuncio;

namespace SecondFloor.ServiceContracts
{
    public interface IAnuncioService
    {
        EncontrarTodosAnunciosResponse EncontrarTodosAnuncios(EncontrarTodosAnunciosRequest request);
        EncontrarAnuncioResponse EncontrarAnuncioPor(EncontrarAnuncioRequest request);
        CadastrarAnuncioResponse CadastrarAnuncio(CadastrarAnuncioRequest request);
        AlterarAnuncioResponse AlterarAnuncio(AlterarAnuncioRequest request);
        ExcluirAnuncioResponse ExcluirAnuncio(ExcluirAnuncioRequest request);
        PublicarAnuncioResponse PublicarAnuncio(PublicarAnuncioRequest request);
    }
}