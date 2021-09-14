using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos
{
    public class ServicoNoticia : IServicoNoticia

    {

        private readonly INoticia _INoticia;

        public ServicoNoticia(INoticia INoticia)
        {
            _INoticia = INoticia;
        }
        public async Task AdicionaNoticia(Noticia noticia)
        {
            var ValidarTitulo = noticia.ValidaPropriedadeString(noticia.Titulo, "Titulo");
            var ValidarInformacao = noticia.ValidaPropriedadeString(noticia.Informação, "Informação");
            if (ValidarTitulo && ValidarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Adicionar(noticia);
            }
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            var ValidarTitulo = noticia.ValidaPropriedadeString(noticia.Titulo, "Titulo");
            var ValidarInformacao = noticia.ValidaPropriedadeString(noticia.Informação, "Informação");
            if (ValidarTitulo && ValidarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Adicionar(noticia);
            }
        }

        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _INoticia.ListarNoticias(n => n.Ativo);
        }
    }
}
