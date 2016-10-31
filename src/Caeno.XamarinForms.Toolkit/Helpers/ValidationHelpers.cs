using System;
using System.Text.RegularExpressions;

namespace Caeno.XamarinForms.Toolkit {
	
	public static class ValidationHelpers {

        /// <summary>
        /// Validates a Brazilian "CPF" number.
        /// </summary>
        /// <param name="cpf">The CPF Number.</param>
        /// <returns><c>true</c>, if valid CPF is passed.</returns>
        /// <remarks>
        /// This code is based on the following resource: http://www.macoratti.net/11/09/c_val1.htm
        /// </remarks>
        public static bool CheckValidCpf(string cpf) {
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}

		/// <summary>
		/// Validates if this instance of string is valid Brazilian "CPF" number.
		/// </summary>
		/// <returns><c>true</c> if this instance is a valid CPF number.</returns>
		public static bool IsValidCpf(this string cpf) {
			return CheckValidCpf(cpf);
		}

        /// <summary>
        /// Validates a Brazilian "CNPJ" number.
        /// </summary>
        /// <param name="cnpj">The CNPJ number to validate.</param>
        /// <returns><c>true</c>, if valid CNPJ is passed.</returns>
        /// <remarks>
        /// This code is based on the following resource: http://www.macoratti.net/11/09/c_val1.htm
        /// </remarks>
        public static bool CheckValidCnpj(string cnpj) {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        /// <summary>
        /// Validates if this instance of string is valid Brazilian "CNPJ" number.
        /// </summary>
        /// <param name="cnpj">The CNPJ number to validate.</param>
        /// <returns><c>true</c> if this is instance is a valid CNPJ number.</returns>
        public static bool IsValidCnpj(this string cnpj) {
            return CheckValidCnpj(cnpj);
        }

        /// <summary>
        /// Validates a Brazilian "PIS" number.
        /// </summary>
        /// <param name="pis">The PIS number to validate.</param>
        /// <returns><c>true</c>, if valid PIS is passed.</returns>
        /// <remarks>
        /// This code is based on the following resource: http://www.macoratti.net/11/09/c_val1.htm
        /// </remarks>
        public static bool CheckValidPis(string pis) {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }

        /// <summary>
        /// Validates if this instance of string is valid Brazilian "PIS" number.
        /// </summary>
        /// <param name="pis">The PIS number to validate.</param>
        /// <returns><c>true</c>, if valid PIS is passed.</returns>
        public static bool IsValidPis(this string pis) {
            return CheckValidPis(pis);
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <returns><c>true</c>, if valid email address, <c>false</c> otherwise.</returns>
        /// <param name="email">The email address.</param>
        public static bool CheckValidEmail(string email) {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            return match.Success;
        }

        /// <summary>
        /// Validates if this instance of string is a valid email address.
        /// </summary>
        /// <returns><c>true</c>, if valid email address, <c>false</c> otherwise.</returns>
        public static bool IsValidEmail(this string email) {
            return CheckValidEmail(email);
        }

    }

}
