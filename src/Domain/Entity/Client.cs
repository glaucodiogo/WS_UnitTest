using System;
using System.Data;
using System.Net.Mail;

namespace Domain
{
    //public class Cliente
    //{
    //    public int ClienteId { get; set; }
    //    public string Nome { get; set; }
    //    public string Email { get; set; }
    //    public string CPF { get; set; }
    //    public DateTime DataCadastro { get; set; }

    //    public string AdicionarCliente()
    //    {
    //        if (!Email.Contains("@"))
    //            return "Cliente com e-mail inválido";

    //        if (CPF.Length != 11)
    //            return "Cliente com CPF inválido";


    //        using (var cn = new SqlConnection())
    //        {
    //            var cmd = new SqlCommand();

    //            cn.ConnectionString = "MinhaConnectionString";
    //            cmd.Connection = cn;
    //            cmd.CommandType = CommandType.Text;
    //            cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL CPF, DATACADASTRO) VALUES (@nome, @email, @cpf, @dataCad))";

    //            cmd.Parameters.AddWithValue("nome", Nome);
    //            cmd.Parameters.AddWithValue("email", Email);
    //            cmd.Parameters.AddWithValue("cpf", CPF);
    //            cmd.Parameters.AddWithValue("dataCad", DataCadastro);

    //            cn.Open();
    //            cmd.ExecuteNonQuery();
    //        }

    //        var mail = new MailMessage("empresa@empresa.com", Email);
    //        var client = new SmtpClient
    //        {
    //            Port = 25,
    //            DeliveryMethod = SmtpDeliveryMethod.Network,
    //            UseDefaultCredentials = false,
    //            Host = "smtp.google.com"
    //        };

    //        mail.Subject = "Bem Vindo.";
    //        mail.Body = "Parabéns! Você está cadastrado.";
    //        client.Send(mail);

    //        return "Cliente cadastrado com sucesso!";
    //    }

        #region S 
        //public class Cliente
        //{
        //    public int ClienteId { get; set; }
        //    public string Nome { get; set; }
        //    public Email Email { get; set; }
        //    public Cpf Cpf { get; set; }
        //    public DateTime DataCadastro { get; set; }

        //    public bool Validar()
        //    {
        //        return Email.Validar() && Cpf.Validar();
        //    }
        //}
        #endregion

        #region repositoryPattern
            //public class ClienteRepository
            //{
            //    public void AdicionarCliente(Cliente cliente)
            //    {
            //        using (var cn = new SqlConnection())
            //        {
            //            var cmd = new SqlCommand();

            //            cn.ConnectionString = "MinhaConnectionString";
            //            cmd.Connection = cn;
            //            cmd.CommandType = CommandType.Text;
            //            cmd.CommandText = "INSERT INTO CLIENTE (NOME, EMAIL CPF, DATACADASTRO) VALUES (@nome, @email, @cpf, @dataCad))";

            //            cmd.Parameters.AddWithValue("nome", cliente.Nome);
            //            cmd.Parameters.AddWithValue("email", cliente.Email);
            //            cmd.Parameters.AddWithValue("cpf", cliente.Cpf);
            //            cmd.Parameters.AddWithValue("dataCad", cliente.DataCadastro);

            //            cn.Open();
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
        #endregion
   
}