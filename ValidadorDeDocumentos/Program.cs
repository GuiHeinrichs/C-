using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Inwords;
using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorDeDocumentos{
    class Program{
        static void Main(string[] args){
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

            //EUA

            string toEUR = new MoedaEUR(valueTest).Extenso();
            Debug.WriteLine(toEUR);

            //USD

            string toUSD = new MoedaUSD(valueTest).Extenso();
            Debug.WriteLine(toUSD);

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
