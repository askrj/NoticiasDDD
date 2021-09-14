using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<AplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioUsuario()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }

        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {

            try
            {
                using (var data = new Contexto(_OptionsBuilder))
                {
                    await data.AplicationUser.AddAsync(
                        new AplicationUser
                        {
                            Email = email,
                            PasswordHash = senha,
                            Idade = idade,
                            Celular = celular
                        });

                    await data.SaveChangesAsync();

                }
            }
            catch (Exception)
            {

                return false;
            }

            return true;    
        }
    }
}
