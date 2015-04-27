using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStreaming
{
    public class JWTManager
    {
        public static object DecodeToken(string token)
        {
            object jsonPayload;

            var secretKey = "8FJ58GKJ.K45K1HSNVA7Q_DKD?'23SGHJ456";

            try
            {
                jsonPayload = JWT.JsonWebToken.DecodeToObject(token, secretKey);
            }
            catch (JWT.SignatureVerificationException)
            {
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return jsonPayload;
        }
    }
}
