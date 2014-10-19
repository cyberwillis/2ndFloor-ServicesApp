using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SecondFloor.Web.Mvc.Models
{
    public class AnuncioViewModels
    {
        public string Id { get; set; }

        public string Titulo { get; set; }

        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string Status { get; set; }

        public string EnderecoId { get; set; }

        public EnderecoViewModels Endereco { get; set; }

        public IList<EnderecoViewModels> Enderecos { get; set; }

        public IList<OfertaViewModels> Ofertas { get; set; }

        public string AnuncianteId { get; set; }
        
        public SelectList GetEnderecosSelectList()
        {
            var list = new List<EnderecoViewModels>();

            if (Enderecos != null)
            {
                list.AddRange(Enderecos);
            }

            return new SelectList(list, "Id", "LogradouroCompleto");
        }

        public AnuncioViewModels()
        {
            Endereco = new EnderecoViewModels();
        }
    }
}