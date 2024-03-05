using Com.Core.Entities;
using Com.ViewModel;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Components.Web;
 


namespace Com.Services.File
{
    public interface IServices_FilePDF
    {
        public Task<string> GetHTML(UserInfo user);
         public Task<byte[]> CreatePDF(string htmlContent);
 
    }

    public class Services_FilePDF : IServices_FilePDF
    {
        private readonly IConverter _converter;
       
        public Services_FilePDF(IConverter converter)
        {
           _converter = converter;
        }
    


        public Task<byte[]> CreatePDF(string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 20, Bottom = 10, Left = 30, Right = 30 },
                DocumentTitle = "User",
                
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 8, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                FooterSettings = { FontSize = 8, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                
            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return Task.FromResult(_converter.Convert(document));
        }


        public Task<string> GetHTML(UserInfo user)
        {
            string htmlTempleat = $@"
                    <!doctype html>
                        <html lang=""en"">
                          

                          <body>

                            <!-- Begin page content -->
                            <main role=""main"" class=""container"">
                              <h1 class=""mt-5""> {user.Name}</h1>
                                <p class=""lead"">
                                 {user.Location}
                                </p>
                              <p>{user.Phonenumber}</p>
                            </main>

                            
                          </body>

                        </html>
 
                         ";


            return Task.FromResult(htmlTempleat);
         }

        
    }
}
