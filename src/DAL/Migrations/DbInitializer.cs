﻿using DAL.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Migrations
{
    public class DbInitializer
    {
        public static void Initialize(MyDBContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (!context.Country.Any())
                {
                    SeedCountries(context);
                }                
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public static void SeedCountries(MyDBContext context)
        {
            context.Country.AddRange(
                new List<ENT.Ent.Country>
                {
                    new ENT.Ent.Country { Iso = "AF", Name = "AFGHANISTAN", PrintableName = "Afghanistan", Iso3 = "AFG", NumCode = "004" },
                    new ENT.Ent.Country { Iso = "AL", Name = "ALBANIA", PrintableName = "Albania", Iso3 = "ALB", NumCode = "008" },
                    new ENT.Ent.Country { Iso = "DZ", Name = "ALGERIA", PrintableName = "Algeria", Iso3 = "DZA", NumCode = "012" },
                    new ENT.Ent.Country { Iso = "AS", Name = "AMERICAN SAMOA", PrintableName = "American Samoa", Iso3 = "ASM", NumCode = "016" },
                    new ENT.Ent.Country { Iso = "AD", Name = "ANDORRA", PrintableName = "Andorra", Iso3 = "AND", NumCode = "020" },
                    new ENT.Ent.Country { Iso = "AO", Name = "ANGOLA", PrintableName = "Angola", Iso3 = "AGO", NumCode = "024" },
                    new ENT.Ent.Country { Iso = "AI", Name = "ANGUILLA", PrintableName = "Anguilla", Iso3 = "AIA", NumCode = "660" },
                    new ENT.Ent.Country { Iso = "AQ", Name = "ANTARCTICA", PrintableName = "Antarctica", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "AG", Name = "ANTIGUA AND BARBUDA", PrintableName = "Antigua and Barbuda", Iso3 = "ATG", NumCode = "028" },
                    new ENT.Ent.Country { Iso = "AR", Name = "ARGENTINA", PrintableName = "Argentina", Iso3 = "ARG", NumCode = "032" },
                    new ENT.Ent.Country { Iso = "AM", Name = "ARMENIA", PrintableName = "Armenia", Iso3 = "ARM", NumCode = "051" },
                    new ENT.Ent.Country { Iso = "AW", Name = "ARUBA", PrintableName = "Aruba", Iso3 = "ABW", NumCode = "533" },
                    new ENT.Ent.Country { Iso = "AU", Name = "AUSTRALIA", PrintableName = "Australia", Iso3 = "AUS", NumCode = "036" },
                    new ENT.Ent.Country { Iso = "AT", Name = "AUSTRIA", PrintableName = "Austria", Iso3 = "AUT", NumCode = "040" },
                    new ENT.Ent.Country { Iso = "AZ", Name = "AZERBAIJAN", PrintableName = "Azerbaijan", Iso3 = "AZE", NumCode = "031" },
                    new ENT.Ent.Country { Iso = "BS", Name = "BAHAMAS", PrintableName = "Bahamas", Iso3 = "BHS", NumCode = "044" },
                    new ENT.Ent.Country { Iso = "BH", Name = "BAHRAIN", PrintableName = "Bahrain", Iso3 = "BHR", NumCode = "048" },
                    new ENT.Ent.Country { Iso = "BD", Name = "BANGLADESH", PrintableName = "Bangladesh", Iso3 = "BGD", NumCode = "050" },
                    new ENT.Ent.Country { Iso = "BB", Name = "BARBADOS", PrintableName = "Barbados", Iso3 = "BRB", NumCode = "052" },
                    new ENT.Ent.Country { Iso = "BY", Name = "BELARUS", PrintableName = "Belarus", Iso3 = "BLR", NumCode = "112" },
                    new ENT.Ent.Country { Iso = "BE", Name = "BELGIUM", PrintableName = "Belgium", Iso3 = "BEL", NumCode = "056" },
                    new ENT.Ent.Country { Iso = "BZ", Name = "BELIZE", PrintableName = "Belize", Iso3 = "BLZ", NumCode = "084" },
                    new ENT.Ent.Country { Iso = "BJ", Name = "BENIN", PrintableName = "Benin", Iso3 = "BEN", NumCode = "204" },
                    new ENT.Ent.Country { Iso = "BM", Name = "BERMUDA", PrintableName = "Bermuda", Iso3 = "BMU", NumCode = "060" },
                    new ENT.Ent.Country { Iso = "BT", Name = "BHUTAN", PrintableName = "Bhutan", Iso3 = "BTN", NumCode = "064" },
                    new ENT.Ent.Country { Iso = "BO", Name = "BOLIVIA", PrintableName = "Bolivia", Iso3 = "BOL", NumCode = "068" },
                    new ENT.Ent.Country { Iso = "BA", Name = "BOSNIA AND HERZEGOVINA", PrintableName = "Bosnia and Herzegovina", Iso3 = "BIH", NumCode = "070" },
                    new ENT.Ent.Country { Iso = "BW", Name = "BOTSWANA", PrintableName = "Botswana", Iso3 = "BWA", NumCode = "072" },
                    new ENT.Ent.Country { Iso = "BV", Name = "BOUVET ISLAND", PrintableName = "Bouvet Island", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "BR", Name = "BRAZIL", PrintableName = "Brazil", Iso3 = "BRA", NumCode = "076" },
                    new ENT.Ent.Country { Iso = "IO", Name = "BRITISH INDIAN OCEAN TERRITORY", PrintableName = "British Indian Ocean Territory", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "BN", Name = "BRUNEI DARUSSALAM", PrintableName = "Brunei Darussalam", Iso3 = "BRN", NumCode = "096" },
                    new ENT.Ent.Country { Iso = "BG", Name = "BULGARIA", PrintableName = "Bulgaria", Iso3 = "BGR", NumCode = "100" },
                    new ENT.Ent.Country { Iso = "BF", Name = "BURKINA FASO", PrintableName = "Burkina Faso", Iso3 = "BFA", NumCode = "854" },
                    new ENT.Ent.Country { Iso = "BI", Name = "BURUNDI", PrintableName = "Burundi", Iso3 = "BDI", NumCode = "108" },
                    new ENT.Ent.Country { Iso = "KH", Name = "CAMBODIA", PrintableName = "Cambodia", Iso3 = "KHM", NumCode = "116" },
                    new ENT.Ent.Country { Iso = "CM", Name = "CAMEROON", PrintableName = "Cameroon", Iso3 = "CMR", NumCode = "120" },
                    new ENT.Ent.Country { Iso = "CA", Name = "CANADA", PrintableName = "Canada", Iso3 = "CAN", NumCode = "124" },
                    new ENT.Ent.Country { Iso = "CV", Name = "CAPE VERDE", PrintableName = "Cape Verde", Iso3 = "CPV", NumCode = "132" },
                    new ENT.Ent.Country { Iso = "KY", Name = "CAYMAN ISLANDS", PrintableName = "Cayman Islands", Iso3 = "CYM", NumCode = "136" },
                    new ENT.Ent.Country { Iso = "CF", Name = "CENTRAL AFRICAN REPUBLIC", PrintableName = "Central African Republic", Iso3 = "CAF", NumCode = "140" },
                    new ENT.Ent.Country { Iso = "TD", Name = "CHAD", PrintableName = "Chad", Iso3 = "TCD", NumCode = "148" },
                    new ENT.Ent.Country { Iso = "CL", Name = "CHILE", PrintableName = "Chile", Iso3 = "CHL", NumCode = "152" },
                    new ENT.Ent.Country { Iso = "CN", Name = "CHINA", PrintableName = "China", Iso3 = "CHN", NumCode = "156" },
                    new ENT.Ent.Country { Iso = "CX", Name = "CHRISTMAS ISLAND", PrintableName = "Christmas Island", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "CC", Name = "COCOS (KEELING) ISLANDS", PrintableName = "Cocos (Keeling) Islands", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "CO", Name = "COLOMBIA", PrintableName = "Colombia", Iso3 = "COL", NumCode = "170" },
                    new ENT.Ent.Country { Iso = "KM", Name = "COMOROS", PrintableName = "Comoros", Iso3 = "COM", NumCode = "174" },
                    new ENT.Ent.Country { Iso = "CG", Name = "CONGO", PrintableName = "Congo", Iso3 = "COG", NumCode = "178" },
                    new ENT.Ent.Country { Iso = "CD", Name = "CONGO  THE DEMOCRATIC REPUBLIC OF THE", PrintableName = "Congo the Democratic Republic of the", Iso3 = "COD", NumCode = "180" },
                    new ENT.Ent.Country { Iso = "CK", Name = "COOK ISLANDS", PrintableName = "Cook Islands", Iso3 = "COK", NumCode = "184" },
                    new ENT.Ent.Country { Iso = "CR", Name = "COSTA RICA", PrintableName = "Costa Rica", Iso3 = "CRI", NumCode = "188" },
                    new ENT.Ent.Country { Iso = "CI", Name = "COTE D\"IVOIRE", PrintableName = "Cote D\"Ivoire", Iso3 = "CIV", NumCode = "384" },
                    new ENT.Ent.Country { Iso = "HR", Name = "CROATIA", PrintableName = "Croatia", Iso3 = "HRV", NumCode = "191" },
                    new ENT.Ent.Country { Iso = "CU", Name = "CUBA", PrintableName = "Cuba", Iso3 = "CUB", NumCode = "192" },
                    new ENT.Ent.Country { Iso = "CY", Name = "CYPRUS", PrintableName = "Cyprus", Iso3 = "CYP", NumCode = "196" },
                    new ENT.Ent.Country { Iso = "CZ", Name = "CZECH REPUBLIC", PrintableName = "Czech Republic", Iso3 = "CZE", NumCode = "203" },
                    new ENT.Ent.Country { Iso = "DK", Name = "DENMARK", PrintableName = "Denmark", Iso3 = "DNK", NumCode = "208" },
                    new ENT.Ent.Country { Iso = "DJ", Name = "DJIBOUTI", PrintableName = "Djibouti", Iso3 = "DJI", NumCode = "262" },
                    new ENT.Ent.Country { Iso = "DM", Name = "DOMINICA", PrintableName = "Dominica", Iso3 = "DMA", NumCode = "212" },
                    new ENT.Ent.Country { Iso = "DO", Name = "DOMINICAN REPUBLIC", PrintableName = "Dominican Republic", Iso3 = "DOM", NumCode = "214" },
                    new ENT.Ent.Country { Iso = "EC", Name = "ECUADOR", PrintableName = "Ecuador", Iso3 = "ECU", NumCode = "218" },
                    new ENT.Ent.Country { Iso = "EG", Name = "EGYPT", PrintableName = "Egypt", Iso3 = "EGY", NumCode = "818" },
                    new ENT.Ent.Country { Iso = "SV", Name = "EL SALVADOR", PrintableName = "El Salvador", Iso3 = "SLV", NumCode = "222" },
                    new ENT.Ent.Country { Iso = "GQ", Name = "EQUATORIAL GUINEA", PrintableName = "Equatorial Guinea", Iso3 = "GNQ", NumCode = "226" },
                    new ENT.Ent.Country { Iso = "ER", Name = "ERITREA", PrintableName = "Eritrea", Iso3 = "ERI", NumCode = "232" },
                    new ENT.Ent.Country { Iso = "EE", Name = "ESTONIA", PrintableName = "Estonia", Iso3 = "EST", NumCode = "233" },
                    new ENT.Ent.Country { Iso = "ET", Name = "ETHIOPIA", PrintableName = "Ethiopia", Iso3 = "ETH", NumCode = "231" },
                    new ENT.Ent.Country { Iso = "FK", Name = "FALKLAND ISLANDS (MALVINAS)", PrintableName = "Falkland Islands (Malvinas)", Iso3 = "FLK", NumCode = "238" },
                    new ENT.Ent.Country { Iso = "FO", Name = "FAROE ISLANDS", PrintableName = "Faroe Islands", Iso3 = "FRO", NumCode = "234" },
                    new ENT.Ent.Country { Iso = "FJ", Name = "FIJI", PrintableName = "Fiji", Iso3 = "FJI", NumCode = "242" },
                    new ENT.Ent.Country { Iso = "FI", Name = "FINLAND", PrintableName = "Finland", Iso3 = "FIN", NumCode = "246" },
                    new ENT.Ent.Country { Iso = "FR", Name = "FRANCE", PrintableName = "France", Iso3 = "FRA", NumCode = "250" },
                    new ENT.Ent.Country { Iso = "GF", Name = "FRENCH GUIANA", PrintableName = "French Guiana", Iso3 = "GUF", NumCode = "254" },
                    new ENT.Ent.Country { Iso = "PF", Name = "FRENCH POLYNESIA", PrintableName = "French Polynesia", Iso3 = "PYF", NumCode = "258" },
                    new ENT.Ent.Country { Iso = "TF", Name = "FRENCH SOUTHERN TERRITORIES", PrintableName = "French Southern Territories", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "GA", Name = "GABON", PrintableName = "Gabon", Iso3 = "GAB", NumCode = "266" },
                    new ENT.Ent.Country { Iso = "GM", Name = "GAMBIA", PrintableName = "Gambia", Iso3 = "GMB", NumCode = "270" },
                    new ENT.Ent.Country { Iso = "GE", Name = "GEORGIA", PrintableName = "Georgia", Iso3 = "GEO", NumCode = "268" },
                    new ENT.Ent.Country { Iso = "DE", Name = "GERMANY", PrintableName = "Germany", Iso3 = "DEU", NumCode = "276" },
                    new ENT.Ent.Country { Iso = "GH", Name = "GHANA", PrintableName = "Ghana", Iso3 = "GHA", NumCode = "288" },
                    new ENT.Ent.Country { Iso = "GI", Name = "GIBRALTAR", PrintableName = "Gibraltar", Iso3 = "GIB", NumCode = "292" },
                    new ENT.Ent.Country { Iso = "GR", Name = "GREECE", PrintableName = "Greece", Iso3 = "GRC", NumCode = "300" },
                    new ENT.Ent.Country { Iso = "GL", Name = "GREENLAND", PrintableName = "Greenland", Iso3 = "GRL", NumCode = "304" },
                    new ENT.Ent.Country { Iso = "GD", Name = "GRENADA", PrintableName = "Grenada", Iso3 = "GRD", NumCode = "308" },
                    new ENT.Ent.Country { Iso = "GP", Name = "GUADELOUPE", PrintableName = "Guadeloupe", Iso3 = "GLP", NumCode = "312" },
                    new ENT.Ent.Country { Iso = "GU", Name = "GUAM", PrintableName = "Guam", Iso3 = "GUM", NumCode = "316" },
                    new ENT.Ent.Country { Iso = "GT", Name = "GUATEMALA", PrintableName = "Guatemala", Iso3 = "GTM", NumCode = "320" },
                    new ENT.Ent.Country { Iso = "GN", Name = "GUINEA", PrintableName = "Guinea", Iso3 = "GIN", NumCode = "324" },
                    new ENT.Ent.Country { Iso = "GW", Name = "GUINEA-BISSAU", PrintableName = "Guinea-Bissau", Iso3 = "GNB", NumCode = "624" },
                    new ENT.Ent.Country { Iso = "GY", Name = "GUYANA", PrintableName = "Guyana", Iso3 = "GUY", NumCode = "328" },
                    new ENT.Ent.Country { Iso = "HT", Name = "HAITI", PrintableName = "Haiti", Iso3 = "HTI", NumCode = "332" },
                    new ENT.Ent.Country { Iso = "HM", Name = "HEARD ISLAND AND MCDONALD ISLANDS", PrintableName = "Heard Island and Mcdonald Islands", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "VA", Name = "HOLY SEE (VATICAN CITY STATE)", PrintableName = "Holy See (Vatican City State)", Iso3 = "VAT", NumCode = "336" },
                    new ENT.Ent.Country { Iso = "HN", Name = "HONDURAS", PrintableName = "Honduras", Iso3 = "HND", NumCode = "340" },
                    new ENT.Ent.Country { Iso = "HK", Name = "HONG KONG", PrintableName = "Hong Kong", Iso3 = "HKG", NumCode = "344" },
                    new ENT.Ent.Country { Iso = "HU", Name = "HUNGARY", PrintableName = "Hungary", Iso3 = "HUN", NumCode = "348" },
                    new ENT.Ent.Country { Iso = "IS", Name = "ICELAND", PrintableName = "Iceland", Iso3 = "ISL", NumCode = "352" },
                    new ENT.Ent.Country { Iso = "IN", Name = "INDIA", PrintableName = "India", Iso3 = "IND", NumCode = "356" },
                    new ENT.Ent.Country { Iso = "ID", Name = "INDONESIA", PrintableName = "Indonesia", Iso3 = "IDN", NumCode = "360" },
                    new ENT.Ent.Country { Iso = "IR", Name = "IRAN ISLAMIC REPUBLIC OF", PrintableName = "Iran  Islamic Republic of", Iso3 = "IRN", NumCode = "364" },
                    new ENT.Ent.Country { Iso = "IQ", Name = "IRAQ", PrintableName = "Iraq", Iso3 = "IRQ", NumCode = "368" },
                    new ENT.Ent.Country { Iso = "IE", Name = "IRELAND", PrintableName = "Ireland", Iso3 = "IRL", NumCode = "372" },
                    new ENT.Ent.Country { Iso = "IL", Name = "ISRAEL", PrintableName = "Israel", Iso3 = "ISR", NumCode = "376" },
                    new ENT.Ent.Country { Iso = "IT", Name = "ITALY", PrintableName = "Italy", Iso3 = "ITA", NumCode = "380" },
                    new ENT.Ent.Country { Iso = "JM", Name = "JAMAICA", PrintableName = "Jamaica", Iso3 = "JAM", NumCode = "388" },
                    new ENT.Ent.Country { Iso = "JP", Name = "JAPAN", PrintableName = "Japan", Iso3 = "JPN", NumCode = "392" },
                    new ENT.Ent.Country { Iso = "JO", Name = "JORDAN", PrintableName = "Jordan", Iso3 = "JOR", NumCode = "400" },
                    new ENT.Ent.Country { Iso = "KZ", Name = "KAZAKHSTAN", PrintableName = "Kazakhstan", Iso3 = "KAZ", NumCode = "398" },
                    new ENT.Ent.Country { Iso = "KE", Name = "KENYA", PrintableName = "Kenya", Iso3 = "KEN", NumCode = "404" },
                    new ENT.Ent.Country { Iso = "KI", Name = "KIRIBATI", PrintableName = "Kiribati", Iso3 = "KIR", NumCode = "296" },
                    new ENT.Ent.Country { Iso = "KP", Name = "KOREA  DEMOCRATIC PEOPLE\"S REPUBLIC OF", PrintableName = "Korea Democratic People\"s Republic of", Iso3 = "PRK", NumCode = "408" },
                    new ENT.Ent.Country { Iso = "KR", Name = "KOREA REPUBLIC OF", PrintableName = "Korea Republic of", Iso3 = "KOR", NumCode = "410" },
                    new ENT.Ent.Country { Iso = "KW", Name = "KUWAIT", PrintableName = "KWT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "KG", Name = "KYRGYZSTAN", PrintableName = "KGZ", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LA", Name = "LAO PEOPLE\"S DEMOCRATIC REPUBLIC", PrintableName = "LAO", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LV", Name = "LATVIA", PrintableName = "LVA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LB", Name = "LEBANON", PrintableName = "LBN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LS", Name = "LESOTHO", PrintableName = "LSO", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LR", Name = "LIBERIA", PrintableName = "LBR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LY", Name = "LIBYAN ARAB JAMAHIRIYA", PrintableName = "LBY", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LI", Name = "LIECHTENSTEIN", PrintableName = "LIE", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LT", Name = "LITHUANIA", PrintableName = "LTU", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LU", Name = "LUXEMBOURG", PrintableName = "LUX", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MO", Name = "MACAO", PrintableName = "MAC", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MK", Name = "MACEDONIA THE FORMER YUGOSLAV REPUBLIC OF", PrintableName = "Macedonia the Former Yugoslav Republic of", Iso3 = "MKD", NumCode = "807" },
                    new ENT.Ent.Country { Iso = "MG", Name = "MADAGASCAR", PrintableName = "MDG", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MW", Name = "MALAWI", PrintableName = "MWI", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MY", Name = "MALAYSIA", PrintableName = "MYS", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MV", Name = "MALDIVES", PrintableName = "MDV", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "ML", Name = "MALI", PrintableName = "MLI", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MT", Name = "MALTA", PrintableName = "MLT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MH", Name = "MARSHALL ISLANDS", PrintableName = "MHL", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MQ", Name = "MARTINIQUE", PrintableName = "MTQ", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MR", Name = "MAURITANIA", PrintableName = "MRT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MU", Name = "MAURITIUS", PrintableName = "MUS", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "YT", Name = "MAYOTTE", PrintableName = null, Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MX", Name = "MEXICO", PrintableName = "MEX", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "FM", Name = "MICRONESIA FEDERATED STATES OF", PrintableName = "Micronesia Federated States of", Iso3 = "FSM", NumCode = "583" },
                    new ENT.Ent.Country { Iso = "MD", Name = "MOLDOVA REPUBLIC OF", PrintableName = "Moldova Republic of", Iso3 = "MDA", NumCode = "498" },
                    new ENT.Ent.Country { Iso = "MC", Name = "MONACO", PrintableName = "MCO", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MN", Name = "MONGOLIA", PrintableName = "MNG", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MS", Name = "MONTSERRAT", PrintableName = "MSR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MA", Name = "MOROCCO", PrintableName = "MAR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MZ", Name = "MOZAMBIQUE", PrintableName = "MOZ", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MM", Name = "MYANMAR", PrintableName = "MMR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NA", Name = "NAMIBIA", PrintableName = "NAM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NR", Name = "NAURU", PrintableName = "NRU", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NP", Name = "NEPAL", PrintableName = "NPL", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NL", Name = "NETHERLANDS", PrintableName = "NLD", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "AN", Name = "NETHERLANDS ANTILLES", PrintableName = "ANT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NC", Name = "NEW CALEDONIA", PrintableName = "NCL", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NZ", Name = "NEW ZEALAND", PrintableName = "NZL", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NI", Name = "NICARAGUA", PrintableName = "NIC", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NE", Name = "NIGER", PrintableName = "NER", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NG", Name = "NIGERIA", PrintableName = "NGA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NU", Name = "NIUE", PrintableName = "NIU", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NF", Name = "NORFOLK ISLAND", PrintableName = "NFK", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "MP", Name = "NORTHERN MARIANA ISLANDS", PrintableName = "MNP", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "NO", Name = "NORWAY", PrintableName = "NOR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "OM", Name = "OMAN", PrintableName = "OMN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PK", Name = "PAKISTAN", PrintableName = "PAK", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PW", Name = "PALAU", PrintableName = "PLW", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PS", Name = "PALESTINIAN TERRITORY OCCUPIED", PrintableName = "Palestinian Territory Occupied", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PA", Name = "PANAMA", PrintableName = "PAN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PG", Name = "PAPUA NEW GUINEA", PrintableName = "PNG", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PY", Name = "PARAGUAY", PrintableName = "PRY", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PE", Name = "PERU", PrintableName = "PER", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PH", Name = "PHILIPPINES", PrintableName = "PHL", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PN", Name = "PITCAIRN", PrintableName = "PCN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PL", Name = "POLAND", PrintableName = "POL", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PT", Name = "PORTUGAL", PrintableName = "PRT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PR", Name = "PUERTO RICO", PrintableName = "PRI", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "QA", Name = "QATAR", PrintableName = "QAT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "RE", Name = "REUNION", PrintableName = "REU", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "RO", Name = "ROMANIA", PrintableName = "ROM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "RU", Name = "RUSSIAN FEDERATION", PrintableName = "RUS", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "RW", Name = "RWANDA", PrintableName = "RWA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SH", Name = "SAINT HELENA", PrintableName = "SHN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "KN", Name = "SAINT KITTS AND NEVIS", PrintableName = "KNA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LC", Name = "SAINT LUCIA", PrintableName = "LCA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "PM", Name = "SAINT PIERRE AND MIQUELON", PrintableName = "SPM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "VC", Name = "SAINT VINCENT AND THE GRENADINES", PrintableName = "VCT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "WS", Name = "SAMOA", PrintableName = "WSM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SM", Name = "SAN MARINO", PrintableName = "SMR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "ST", Name = "SAO TOME AND PRINCIPE", PrintableName = "STP", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SA", Name = "SAUDI ARABIA", PrintableName = "SAU", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SN", Name = "SENEGAL", PrintableName = "SEN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "CS", Name = "SERBIA AND MONTENEGRO", PrintableName = null, Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SC", Name = "SEYCHELLES", PrintableName = "SYC", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SL", Name = "SIERRA LEONE", PrintableName = "SLE", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SG", Name = "SINGAPORE", PrintableName = "SGP", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SK", Name = "SLOVAKIA", PrintableName = "SVK", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SI", Name = "SLOVENIA", PrintableName = "SVN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SB", Name = "SOLOMON ISLANDS", PrintableName = "SLB", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SO", Name = "SOMALIA", PrintableName = "SOM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "ZA", Name = "SOUTH AFRICA", PrintableName = "ZAF", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "GS", Name = "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS", PrintableName = null, Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "ES", Name = "SPAIN", PrintableName = "ESP", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "LK", Name = "SRI LANKA", PrintableName = "LKA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SD", Name = "SUDAN", PrintableName = "SDN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SR", Name = "SURINAME", PrintableName = "SUR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SJ", Name = "SVALBARD AND JAN MAYEN", PrintableName = "SJM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SZ", Name = "SWAZILAND", PrintableName = "SWZ", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SE", Name = "SWEDEN", PrintableName = "SWE", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "CH", Name = "SWITZERLAND", PrintableName = "CHE", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "SY", Name = "SYRIAN ARAB REPUBLIC", PrintableName = "SYR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TW", Name = "TAIWAN PROVINCE OF CHINA", PrintableName = "Taiwan Province of China", Iso3 = "TWN", NumCode = "158" },
                    new ENT.Ent.Country { Iso = "TJ", Name = "TAJIKISTAN", PrintableName = "TJK", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TZ", Name = "TANZANIA UNITED REPUBLIC OF", PrintableName = "Tanzania United Republic of", Iso3 = "TZA", NumCode = "834" },
                    new ENT.Ent.Country { Iso = "TH", Name = "THAILAND", PrintableName = "THA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TL", Name = "TIMOR-LESTE", PrintableName = null, Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TG", Name = "TOGO", PrintableName = "TGO", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TK", Name = "TOKELAU", PrintableName = "TKL", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TO", Name = "TONGA", PrintableName = "TON", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TT", Name = "TRINIDAD AND TOBAGO", PrintableName = "TTO", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TN", Name = "TUNISIA", PrintableName = "TUN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TR", Name = "TURKEY", PrintableName = "TUR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TM", Name = "TURKMENISTAN", PrintableName = "TKM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TC", Name = "TURKS AND CAICOS ISLANDS", PrintableName = "TCA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "TV", Name = "TUVALU", PrintableName = "TUV", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "UG", Name = "UGANDA", PrintableName = "UGA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "UA", Name = "UKRAINE", PrintableName = "UKR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "AE", Name = "UNITED ARAB EMIRATES", PrintableName = "ARE", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "GB", Name = "UNITED KINGDOM", PrintableName = "GBR", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "US", Name = "UNITED STATES", PrintableName = "USA", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "UM", Name = "UNITED STATES MINOR OUTLYING ISLANDS", PrintableName = null, Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "UY", Name = "URUGUAY", PrintableName = "URY", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "UZ", Name = "UZBEKISTAN", PrintableName = "UZB", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "VU", Name = "VANUATU", PrintableName = "VUT", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "VE", Name = "VENEZUELA", PrintableName = "VEN", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "VN", Name = "VIET NAM", PrintableName = "VNM", Iso3 = null, NumCode = null },
                    new ENT.Ent.Country { Iso = "VG", Name = "VIRGIN ISLANDS BRITISH", PrintableName = "Virgin Islands British", Iso3 = "VGB", NumCode = "092" },
                    new ENT.Ent.Country { Iso = "VI", Name = "VIRGIN ISLANDS U.S.", PrintableName = "Virgin Islands U.s.", Iso3 = "VIR", NumCode = "850" },
                    new ENT.Ent.Country { Iso = "WF", Name = "WALLIS AND FUTUNA", PrintableName = "Wallis and Futuna", Iso3 = "WLF", NumCode = "876" },
                    new ENT.Ent.Country { Iso = "EH", Name = "WESTERN SAHARA", PrintableName = "Western Sahara", Iso3 = "ESH", NumCode = "732" },
                    new ENT.Ent.Country { Iso = "YE", Name = "YEMEN", PrintableName = "Yemen", Iso3 = "YEM", NumCode = "887" },
                    new ENT.Ent.Country { Iso = "ZM", Name = "ZAMBIA", PrintableName = "Zambia", Iso3 = "ZMB", NumCode = "894" },
                    new ENT.Ent.Country { Iso = "ZW", Name = "ZIMBABWE", PrintableName = "Zimbabwe", Iso3 = "ZWE", NumCode = "716" }
                }
            );

            context.SaveChanges();
        }
    }
}
