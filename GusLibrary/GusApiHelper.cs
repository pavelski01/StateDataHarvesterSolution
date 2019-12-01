using DtoLibrary.Gus;
using GusLibrary.BirServiceReference;
using System.Configuration;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Serialization;

namespace GusLibrary
{
    public static class GusApiHelper
    {
        private static UslugaBIRzewnPublClient Client { get; set; }
        private static string Sid { get; set; }

        private static string Login()
        {
            if (Client != null && !string.IsNullOrEmpty(Sid))
            {
                Client.Wyloguj(Sid);
                Client.Close();
            }
            var appSettings = ConfigurationManager.AppSettings;
            var apiKey = appSettings["GusProdKey"];            
            Client = new UslugaBIRzewnPublClient();
            Client.Open();
            Sid = Client.Zaloguj(apiKey);
            if (string.IsNullOrEmpty(Sid))
            {
                apiKey = appSettings["GusTestKey"];
                Sid = Client.Zaloguj(apiKey);
            }
            return Sid;
        }

        public static GusDataDto DataSearchSubjects(string nip)
        {
            var sid = Login();
            var scope = new OperationContextScope(Client.InnerChannel);
            var reqProps = new HttpRequestMessageProperty();
            reqProps.Headers.Add("sid", sid);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = reqProps;
            var queryParam = new ParametryWyszukiwania
            {
                Nip = nip
            };
            var result = Client.DaneSzukajPodmioty(queryParam);
            var serializer = new XmlSerializer(typeof(GusRootObjectDto));
            GusRootObjectDto gusRoot;
            using (var reader = new StringReader(result))
            {
                gusRoot = (GusRootObjectDto)serializer.Deserialize(reader);
            }
            return gusRoot?.Data;
        }


    }
}
