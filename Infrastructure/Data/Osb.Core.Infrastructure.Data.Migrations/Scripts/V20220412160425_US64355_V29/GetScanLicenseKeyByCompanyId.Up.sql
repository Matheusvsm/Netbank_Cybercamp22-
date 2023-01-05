CREATE OR REPLACE FUNCTION public.getscanlicensekeybycompanyid(
	"paramCompanyId" bigint)
    RETURNS TABLE("CompanyId" bigint, "LicenseKey" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$ 
SELECT "CompanyId",
	   "LicenseKey"
	  FROM public."ScanLicenseKey"
	  Where
		"CompanyId" = "paramCompanyId"
	  AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getscanlicensekeybycompanyid(bigint)
    OWNER TO "OSB";

