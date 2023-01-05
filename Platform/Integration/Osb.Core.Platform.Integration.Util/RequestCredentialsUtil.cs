using System;
using System.Text;

namespace Osb.Core.Platform.Integration.Util
{
    /// <summary>
    /// Classe de utilidade para credenciais de requisição.
    /// </summary>
    public static class RequestCredentialsUtil
    {
        /// <summary>
        /// Retorna os dados de uma autenticação do tipo Basic.
        /// </summary>
        /// <remarks>O username e o password são formatados e posteriormente codificados em base64.</remarks>
        /// <param name="username">Usuário da autenticação.</param>
        /// <param name="password">Senha da autenticação.</param>
        /// <returns>Dados da autenticação</returns>
        public static string GetBasicAuthData(string username, string password)
        {
            var formattedCredential = $"{username}:{password}";
            var encodedCredential = Convert.ToBase64String(Encoding.UTF8.GetBytes(formattedCredential));
            return encodedCredential;
        }
    }
}