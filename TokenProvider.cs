using Inquiry__Management__System.InquiryContext;
using Inquiry__Management__System.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Inquiry__Management__System
{
    public class TokenProvider
    {
        private readonly InquiryDbContext _context;

        public TokenProvider(InquiryDbContext context)
        {
            _context = context;
        }

        public string LoginUser(string strEmail, string password)
        {
            byte[] encodedbyte = System.Text.Encoding.Unicode.GetBytes(password);
            string pass = Convert.ToBase64String(encodedbyte);
            string username = strEmail;

            var user = _context.Registrations.SingleOrDefault(x => x.Email == username && x.Password == pass);

            //Authenticate User, Check if its a registered user in DB  - JRozario
            if (user == null)
                return null;

            var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

            var JWToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: GetUserClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,

                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            var strusername = user.Email;

            return token;
        }




        private IEnumerable<Claim> GetUserClaims(Registration user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
           
            _claim = new Claim(ClaimTypes.Email, user.Email);
            claims.Add(_claim);

            _claim = new Claim(ClaimTypes.Role, user.Role);
            claims.Add(_claim);
            return claims.AsEnumerable<Claim>();
        }
    }
}
