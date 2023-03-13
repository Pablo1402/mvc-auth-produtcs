using App.Models;
using AutoMapper;
using Site.ViewModels;

namespace Site.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
                CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
                CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
                CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
