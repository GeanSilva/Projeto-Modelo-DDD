using AutoMapper;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.MVC.Models;

namespace ProjectModeloDDD.MVC.AutoMapper
{
    public class ModelParaDominio : Profile
    {
        public new virtual string ProfileName => "ModelParaDominio";

        protected override void Configure()
        {
            Mapper.CreateMap<ClientesModel, Cliente>();
            Mapper.CreateMap<ProdutosModel, Produto>();
        }
    }
}