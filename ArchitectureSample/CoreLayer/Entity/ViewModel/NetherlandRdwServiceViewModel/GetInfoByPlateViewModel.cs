using System.Text.Json.Serialization;

namespace CoreLayer.Entity.ViewModel.NetherlandRdwServiceViewModel
{
    public class GetInfoByPlateViewModel
    {
        [JsonPropertyName("kenteken")]
        public string Kenteken { get; set; }

        [JsonPropertyName("voertuigsoort")]
        public string Voertuigsoort { get; set; }

        [JsonPropertyName("merk")]
        public string Merk { get; set; }

        [JsonPropertyName("handelsbenaming")]
        public string Handelsbenaming { get; set; }

        [JsonPropertyName("vervaldatum_apk")]
        public string VervaldatumApk { get; set; }

        [JsonPropertyName("datum_tenaamstelling")]
        public string DatumTenaamstelling { get; set; }

        [JsonPropertyName("inrichting")]
        public string Inrichting { get; set; }

        [JsonPropertyName("aantal_zitplaatsen")]
        public string AantalZitplaatsen { get; set; }

        [JsonPropertyName("eerste_kleur")]
        public string EersteKleur { get; set; }

        [JsonPropertyName("tweede_kleur")]
        public string TweedeKleur { get; set; }

        [JsonPropertyName("massa_ledig_voertuig")]
        public string MassaLedigVoertuig { get; set; }

        [JsonPropertyName("toegestane_maximum_massa_voertuig")]
        public string ToegestaneMaximumMassaVoertuig { get; set; }

        [JsonPropertyName("massa_rijklaar")]
        public string MassaRijklaar { get; set; }

        [JsonPropertyName("datum_eerste_toelating")]
        public string DatumEersteToelating { get; set; }

        [JsonPropertyName("datum_eerste_tenaamstelling_in_nederland")]
        public string DatumEersteTenaamstellingInNederland { get; set; }

        [JsonPropertyName("wacht_op_keuren")]
        public string WachtOpKeuren { get; set; }

        [JsonPropertyName("catalogusprijs")]
        public string Catalogusprijs { get; set; }

        [JsonPropertyName("wam_verzekerd")]
        public string WamVerzekerd { get; set; }

        [JsonPropertyName("aantal_deuren")]
        public string AantalDeuren { get; set; }

        [JsonPropertyName("aantal_wielen")]
        public string AantalWielen { get; set; }

        [JsonPropertyName("afstand_hart_koppeling_tot_achterzijde_voertuig")]
        public string AfstandHartKoppelingTotAchterzijdeVoertuig { get; set; }

        [JsonPropertyName("afstand_voorzijde_voertuig_tot_hart_koppeling")]
        public string AfstandVoorzijdeVoertuigTotHartKoppeling { get; set; }

        [JsonPropertyName("lengte")]
        public string Lengte { get; set; }

        [JsonPropertyName("breedte")]
        public string Breedte { get; set; }

        [JsonPropertyName("europese_voertuigcategorie")]
        public string EuropeseVoertuigcategorie { get; set; }

        [JsonPropertyName("plaats_chassisnummer")]
        public string PlaatsChassisnummer { get; set; }

        [JsonPropertyName("technische_max_massa_voertuig")]
        public string TechnischeMaxMassaVoertuig { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("typegoedkeuringsnummer")]
        public string Typegoedkeuringsnummer { get; set; }

        [JsonPropertyName("variant")]
        public string Variant { get; set; }

        [JsonPropertyName("uitvoering")]
        public string Uitvoering { get; set; }

        [JsonPropertyName("volgnummer_wijziging_eu_typegoedkeuring")]
        public string VolgnummerWijzigingEuTypegoedkeuring { get; set; }

        [JsonPropertyName("vermogen_massarijklaar")]
        public string VermogenMassarijklaar { get; set; }

        [JsonPropertyName("wielbasis")]
        public string Wielbasis { get; set; }

        [JsonPropertyName("export_indicator")]
        public string ExportIndicator { get; set; }

        [JsonPropertyName("openstaande_terugroepactie_indicator")]
        public string OpenstaandeTerugroepactieIndicator { get; set; }

        [JsonPropertyName("taxi_indicator")]
        public string TaxiIndicator { get; set; }

        [JsonPropertyName("maximum_massa_samenstelling")]
        public string MaximumMassaSamenstelling { get; set; }

        [JsonPropertyName("aantal_rolstoelplaatsen")]
        public string AantalRolstoelplaatsen { get; set; }

        [JsonPropertyName("maximum_ondersteunende_snelheid")]
        public string MaximumOndersteunendeSnelheid { get; set; }

        [JsonPropertyName("jaar_laatste_registratie_tellerstand")]
        public string JaarLaatsteRegistratieTellerstand { get; set; }

        [JsonPropertyName("tellerstandoordeel")]
        public string Tellerstandoordeel { get; set; }

        [JsonPropertyName("code_toelichting_tellerstandoordeel")]
        public string CodeToelichtingTellerstandoordeel { get; set; }

        [JsonPropertyName("tenaamstellen_mogelijk")]
        public string TenaamstellenMogelijk { get; set; }

        [JsonPropertyName("vervaldatum_apk_dt")]
        public DateTime VervaldatumApkDt { get; set; }

        [JsonPropertyName("datum_tenaamstelling_dt")]
        public DateTime DatumTenaamstellingDt { get; set; }

        [JsonPropertyName("datum_eerste_toelating_dt")]
        public DateTime DatumEersteToelatingDt { get; set; }

        [JsonPropertyName("datum_eerste_tenaamstelling_in_nederland_dt")]
        public DateTime DatumEersteTenaamstellingInNederlandDt { get; set; }

        [JsonPropertyName("hoogte_voertuig")]
        public string HoogteVoertuig { get; set; }

        [JsonPropertyName("api_gekentekende_voertuigen_assen")]
        public string ApiGekentekendeVoertuigenAssen { get; set; }

        [JsonPropertyName("api_gekentekende_voertuigen_brandstof")]
        public string ApiGekentekendeVoertuigenBrandstof { get; set; }

        [JsonPropertyName("api_gekentekende_voertuigen_carrosserie")]
        public string ApiGekentekendeVoertuigenCarrosserie { get; set; }

        [JsonPropertyName("api_gekentekende_voertuigen_carrosserie_specifiek")]
        public string ApiGekentekendeVoertuigenCarrosserieSpecifiek { get; set; }

        [JsonPropertyName("api_gekentekende_voertuigen_voertuigklasse")]
        public string ApiGekentekendeVoertuigenVoertuigklasse { get; set; }
    }
}
