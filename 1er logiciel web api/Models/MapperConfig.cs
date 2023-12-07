using _1er_logiciel_web_api;
using AutoMapper;
namespace AutoMapperDemo
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                    //Configuring Book and BookUpdateDTO
                    cfg.CreateMap<Book, BookUpdateDTO>().ReverseMap();
                    //Configuring Client and ClientUpdateDTO
                    cfg.CreateMap<Client, ClientUpdateDTO>().ReverseMap();
                    //Any Other Mapping Configuration ....
                });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}