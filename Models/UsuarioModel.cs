using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Campo nome é obrigatório!")]
        public string Nome { get; set;}

        [Required(ErrorMessage = "Campo email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="E-mail informado é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento é obrigatório!")]
        public String Data_Nascimento { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"Select ID, NOME,DATA_NASCIMENTO From Usuario where EMAIL = '{Email}' AND Senha ='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if(dt != null)
            {
                if (dt.Rows.Count == 1)
                { 
                    Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    Nome = dt.Rows[0]["NOME"].ToString();
                    Data_Nascimento = dt.Rows[0]["DATA_NASCIMENTO"].ToString();
                return true;
                }
            }

            return false;
        }

        public void RegistrarUsuario()
        {
            string dataNascimento = DateTime.Parse(Data_Nascimento).ToString("yyyy/mm/dd");
            string sql = $"INSERT INTO USUARIO(NOME,EMAIL,SENHA,DATA_NASCIMENTO) VALUES('{Nome}','{Email}', '{Senha}', '{Data_Nascimento}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
