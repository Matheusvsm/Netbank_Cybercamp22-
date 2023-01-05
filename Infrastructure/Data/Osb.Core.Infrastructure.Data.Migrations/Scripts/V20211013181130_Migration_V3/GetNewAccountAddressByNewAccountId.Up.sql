CREATE OR REPLACE FUNCTION public.getnewaccountaddressbynewaccountid(
	"paramNewAccountId" bigint)
    RETURNS TABLE("NewAccountAddressId" bigint, "NewAccountId" bigint, "AddressLine" character varying, "AddressLine2" character varying, "ZipCode" character varying, "Neighborhood" character varying, "CityCode" character varying, "CityName" character varying, "State" character varying, "AddressType" smallint, "Country" character varying, "Complement" character varying, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "NewAccountAddressId",
        "NewAccountId",
        "AddressLine",
        "AddressLine2",
        "ZipCode",
        "Neighborhood",
        "CityCode",
        "CityName",
        "State",
        "AddressType",
        "Country",
        "Complement",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."NewAccountAddress"
WHERE "NewAccountId" = "paramNewAccountId" AND
    "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getnewaccountaddressbynewaccountid(bigint)
    OWNER TO "OSB";