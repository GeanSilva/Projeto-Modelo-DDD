using  AutoMapper;
namespace ProjectModeloDDD.MVC.AutoMapper
{
    public class ConfiguraMapeador
    {
        public static void RestrarMapeador()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DominioParaModel>();
                x.AddProfile<ModelParaDominio>();

            });
        }
    }
}