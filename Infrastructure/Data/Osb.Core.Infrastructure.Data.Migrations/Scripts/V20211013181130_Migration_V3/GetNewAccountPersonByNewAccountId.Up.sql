CREATE OR REPLACE FUNCTION public.getnewaccountpersonbynewaccountid(
	"paramNewAccountId" bigint)
    RETURNS TABLE("NewAccountPersonId" bigint, "NewAccountId" bigint, "TaxId" character varying, "Name" character varying, "Mail" character varying, "Occupation" character varying, "Phone" character varying, "PersonRoleType" integer, "MotherFullName" character varying, "FatherFullName" character varying, "Nationality" character varying, "BirthCity" character varying, "BirthState" character varying, "Gender" integer, "MaritalStatus" integer, "SpouseName" character varying, "IdentityDocument" character varying, "CompanyType" integer, "CompanyActivity" character varying, "ConstitutionDate" timestamp without time zone, "CheckPendingTransfers" boolean, "BirthDate" timestamp without time zone, "PersonName" character varying, "PhoneNumber" character varying, "Nickname" character varying, "PubliclyExposedPerson" boolean, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "NewAccountPersonId",
        "NewAccountId",
        "TaxId",
        "Name",
        "Mail",
        "Occupation",
        "Phone",
        "PersonRoleType",
        "MotherFullName",
        "FatherFullName",
        "Nationality",
        "BirthCity",
        "BirthState",
        "Gender",
        "MaritalStatus",
        "SpouseName",
        "IdentityDocument",
        "CompanyType",
        "CompanyActivity",
        "ConstitutionDate",
        "CheckPendingTransfers",
        "BirthDate",
        "PersonName",
        "PhoneNumber",
        "Nickname",
        "PubliclyExposedPerson",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."NewAccountPerson"
WHERE "NewAccountId" = "paramNewAccountId" AND
    "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getnewaccountpersonbynewaccountid(bigint)
    OWNER TO "OSB";