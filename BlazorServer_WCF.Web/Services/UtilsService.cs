using BlazorServer_WCF.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer_WCF.Web
{
    public class UtilsService
    {
        private readonly NavigationManager navigation;

        public UtilsService(NavigationManager navigation)
        {
            this.navigation = navigation;
        }


        public void NavigateTo(string href, bool isTrue)
        {
            if (isTrue)
                navigation.NavigateTo(href + @"/1");
            else
                navigation.NavigateTo(href);
        }

        public List<JurisdictionModel> GetJurisdiction()
        {
            List<JurisdictionModel> jurisdictions = new List<JurisdictionModel>()
            {
                new JurisdictionModel() { JurisdictionId = 1, JCode = "AL", JName = "Alabama", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 2, JCode = "AK", JName = "Alaska", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 3, JCode = "AZ", JName = "Arizona", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 4, JCode = "AR", JName = "Arkansas", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 5, JCode = "CA", JName = "California", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 6, JCode = "CO", JName = "Colorado", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 7, JCode = "CT", JName = "Connecticut", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 8, JCode = "DE", JName = "Delaware", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 9, JCode = "FL", JName = "Florida", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 10, JCode = "GA", JName = "Georgia", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 11, JCode = "HI", JName = "Hawaii", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 12, JCode = "ID", JName = "Idaho", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 13, JCode = "IL", JName = "Illinois", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 14, JCode = "IN", JName = "Indiana", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 15, JCode = "IA", JName = "Iowa", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 16, JCode = "KS", JName = "Kansas", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 17, JCode = "KY", JName = "Kentucky", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 18, JCode = "LA", JName = "Louisiana", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 19, JCode = "ME", JName = "Maine", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 20, JCode = "MD", JName = "Maryland", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 21, JCode = "MA", JName = "Massachusetts", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 22, JCode = "MI", JName = "Michigan", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 23, JCode = "MN", JName = "Minnesota", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 24, JCode = "MS", JName = "Mississippi", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 25, JCode = "MO", JName = "Missouri", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 26, JCode = "MT", JName = "Montana", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 27, JCode = "NE", JName = "Nebraska", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 28, JCode = "NV", JName = "Nevada", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 29, JCode = "NH", JName = "New Hampshire", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 30, JCode = "NJ", JName = "New Jersey", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 31, JCode = "NM", JName = "New Mexico", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 32, JCode = "NY", JName = "New York", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 33, JCode = "NC", JName = "North Carolina", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 34, JCode = "ND", JName = "North Dakota", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 35, JCode = "OH", JName = "Ohio", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 36, JCode = "OK", JName = "Oklahoma", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 37, JCode = "OR", JName = "Oregon", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 38, JCode = "PA", JName = "Pennsylvania", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 39, JCode = "RI", JName = "Rhode Island", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 40, JCode = "SC", JName = "South Carolina", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 41, JCode = "SD", JName = "South Dakota", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 42, JCode = "TN", JName = "Tennessee", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 43, JCode = "TX", JName = "Texas", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 44, JCode = "UT", JName = "Utah", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 45, JCode = "VT", JName = "Vermont", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 46, JCode = "VA", JName = "Virginia", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 47, JCode = "WA", JName = "Washington", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 48, JCode = "WV", JName = "West Virginia", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 49, JCode = "WI", JName = "Wisconsin", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 50, JCode = "WY", JName = "Wyoming", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 51, JCode = "AS", JName = "American Samoa", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 52, JCode = "DC", JName = "District of Columbia", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 53, JCode = "FM", JName = "Federated States of Micronesia", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 54, JCode = "GU", JName = "Guam", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 55, JCode = "MH", JName = "Marshall Islands", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 56, JCode = "MP", JName = "Northern Mariana Islands", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 57, JCode = "PW", JName = "Palau", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 58, JCode = "PR", JName = "Puerto Rico", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 59, JCode = "VI", JName = "Virgin Islands", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 60, JCode = "MX", JName = "Mexico", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 61, JCode = "US", JName = "US", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 64, JCode = "AB", JName = "ALBERTA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 65, JCode = "BC", JName = "BRITISH COLUMBIA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 66, JCode = "MB", JName = "MANITOBA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 67, JCode = "NB", JName = "NEW BRUNSWICK", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 68, JCode = "NL", JName = "NEWFOUNDLAND", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 69, JCode = "NT", JName = "NORTHWEST TERRITORIES", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 70, JCode = "NS", JName = "NOVA SCOTIA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 71, JCode = "NU", JName = "NUNAVUT", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 72, JCode = "ON", JName = "ONTARIO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 73, JCode = "QC", JName = "QUEBEC", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 74, JCode = "SK", JName = "SASKATCHEWAN", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 75, JCode = "PE", JName = "PRINCE EDWARD ISLAND", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 76, JCode = "AG", JName = "AGUASCALIENTES", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 77, JCode = "BA", JName = "BAJA CALIFORNIA(NORTH)", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 78, JCode = "BJ", JName = "BAJA CALIFORNIA(SOUTH)", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 79, JCode = "CE", JName = "CAMPECHE", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 80, JCode = "CI", JName = "CHIAPAS", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 81, JCode = "CH", JName = "CHIHUAHUA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 82, JCode = "CU", JName = "COAHUILA DE ZARAGOZA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 83, JCode = "CL", JName = "COLIMA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 84, JCode = "DF", JName = "DESTRITO FEDERAL", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 85, JCode = "DO", JName = "DURANGO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 86, JCode = "GX", JName = "GUANAJUATO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 87, JCode = "GR", JName = "GUERRERO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 88, JCode = "HL", JName = "HIDALGO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 89, JCode = "JL", JName = "JALISCO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 90, JCode = "MC", JName = "MICHOACANDE OCAMPO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 91, JCode = "MR", JName = "MORELOS", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 92, JCode = "NA", JName = "NAYARIT", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 93, JCode = "NN", JName = "NEUVO LEON", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 94, JCode = "OA", JName = "OAXACA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 95, JCode = "PB", JName = "PUEBLA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 96, JCode = "QU", JName = "RhQUERETARO DE ARTEAGAode", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 97, JCode = "QR", JName = "QUINTANA ROO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 98, JCode = "SL", JName = "SAN LUIS POTOSI", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 99, JCode = "SI", JName = "SINALOA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 100, JCode = "SO", JName = "SONORA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 101, JCode = "TB", JName = "TABASCO", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 102, JCode = "TA", JName = "TAMAULIPAS", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 103, JCode = "TL", JName = "TLAXCALA", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 104, JCode = "VC", JName = "VERACRUZ-LLAVE", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 105, JCode = "YU", JName = "YUCATAN", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 106, JCode = "ZA", JName = "ZACATECAS", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 107, JCode = "GS", JName = "US GOVERNMENT SERVICE", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 108, JCode = "AA", JName = "US ARMED FORCES AMERICAS", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 109, JCode = "AE", JName = "US ARMED FORCES EUROPE", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null },
                new JurisdictionModel() { JurisdictionId = 110, JCode = "AP", JName = "US ARMED FORCES PACIFIC", CreatedTime = DateTime.Now, UpdatedTime = null, ISO3166 = null }
            };

            return jurisdictions;
        }
    }
}
