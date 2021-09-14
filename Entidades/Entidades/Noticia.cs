using Entidades.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("TB_NOTICIA")]
    public class Noticia : Notifica
    {
        [Column("NTC_ID")]
        public int Id { get; set; }

        [Column("NTC _TITULO")]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Column("NTC _INFORMACAO")]
        [MaxLength(255)]
        public string Informação { get; set; }

        [Column("NTC _ATIVO")]
        public bool Ativo { get; set; }

        [Column("NTC _DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("NTC _DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; }


        [ForeignKey("AplicationUser")]
        [Column(Order =1)]
        public string UserId { get; set; }
        public virtual AplicationUser AplicationUser { get; set; }
    }
}
