using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Http;
using Caelum.Stella.CSharp.Inwords;
using Caelum.Stella.CSharp.Validation;
using Caelum.Stella.CSharp.Vault;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorDeDocumentos{
    class Validators{
        static void Main(string[] args)
        {
            //Validação de documentos com o caelum
            //document validation with caelum

            string cpf1 = "86288366757";
            string cpf2 = "98745366797";
            string cpf3 = "22222222222";

            ValidarCPF(cpf1);
            ValidarCPF(cpf2);
            ValidarCPF(cpf3);

            string cnpj1 = "51241758000152";
            string cnpj2 = "14128481000127";

            ValidarCNPJ(cnpj1);
            ValidarCNPJ(cnpj2);

            string titulo1 = "041372570132";
            string titulo2 = "774387480130";

            ValidarTitulo(titulo1);
            ValidarTitulo(titulo2);

            Debug.WriteLine(cpf1);
            string cpfFormatado = new CPFFormatter().Format(cpf1);
            Debug.WriteLine(cpfFormatado);
            Debug.WriteLine(new CPFFormatter().Format(cpfFormatado));
            Debug.WriteLine(new CPFFormatter().Unformat(cpfFormatado));

            Debug.WriteLine(cnpj1);
            Debug.WriteLine(new CNPJFormatter().Format(cnpj1));

            Debug.WriteLine(titulo1);
            Debug.WriteLine(new TituloEleitoralFormatter().Format(titulo1));

            DateTime data = new DateTime(2022, 05, 08);
            Debug.WriteLine(data.ToString("d", new CultureInfo("pt-BR")));

            Debug.WriteLine(data.ToString("D"));
            Debug.WriteLine(data.ToString("m"));
            Debug.WriteLine(data.ToString("Y"));

            //Lidando com datas e número com Caelum e C#
            //testing Dates and numbers with caelum library and also C# func

            double valueTest = 1231.12;

            string toStr = new Numero(valueTest).Extenso();

            Debug.WriteLine(toStr);

            //Lidando com moeda BR
            //handling with BRL

            string toBRL = new MoedaBRL(valueTest).Extenso();

            Debug.WriteLine(toBRL);

            //EUR

            string toEUR = new MoedaEUR(valueTest).Extenso();
            Debug.WriteLine(toEUR);

            //USD

            string toUSD = new MoedaUSD(valueTest).Extenso();
            Debug.WriteLine(toUSD);

            Money money = 10.00;
            Debug.WriteLine(money);

            double valor1 = 10.00;
            double valor2 = 20.00;
            Money total = valor1 + valor2;
            Debug.WriteLine(total);

            decimal minuendo = 20m;
            decimal subtraendo = 15m;
            Money diferenca = minuendo - subtraendo;
            Debug.WriteLine(diferenca);

            Money euro = new Money(Currency.EUR, 1000);
            Debug.WriteLine(euro);

            Money dolar = new Money(Currency.USD, 1000);
            Debug.WriteLine(dolar);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            Debug.WriteLine(dolar);

            //Using ViaCep
            string cep = "94930060";
            string result = GetEndereco(cep);
            Debug.WriteLine(result);


            //Caelum library
            string cepCaelum = "94930060";
            string resultCaelum = new ViaCEP().GetEnderecoJson(cepCaelum);
            Debug.WriteLine(resultCaelum);

        }

        private static string GetEndereco(string cep)
        {
            string url = "https://viacep.com.br/ws/" + cep + "/json/";

            string result = new HttpClient().GetStringAsync(url).Result;
            return result;
        }

        private static void ValidarTitulo(string titulo){
            if (new TituloEleitoralValidator().IsValid(titulo)){
                Debug.WriteLine("Título válido: " + titulo);
            }else{
                Debug.WriteLine("Título inválido: " + titulo);
            }
        }

        private static void ValidarCNPJ(string cnpj){
            if (new CNPJValidator().IsValid(cnpj)){
                Debug.WriteLine("CNPJ válido: " + cnpj);
            }else{
                Debug.WriteLine("CNPJ inválido: " + cnpj);
            }
        }

        private static void ValidarCPF(string cpf){
            if(new CPFValidator().IsValid(cpf)){
                Debug.WriteLine("CPF válido: " + cpf);
            }else{
                Debug.WriteLine("CPF inválido: " + cpf);
            }
        }



    }
}
