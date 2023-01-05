CREATE OR REPLACE FUNCTION public.getnewaccountbyid(
	"paramNewAccountId" bigint)
    RETURNS TABLE("NewAccountId" bigint, "CompanyId" bigint, "TaxId" character varying, "PersonName" character varying, "PhoneNumber" character varying, "Mail" character varying, "Nickname" character varying, "BirthDate" timestamp without time zone, "MotherFullName" character varying, "FatherFullName" character varying, "Nationality" character varying, "BirthCity" character varying, "BirthState" character varying, "Gender" integer, "Status" integer, "MaritalStatus" integer, "SpouseName" character varying, "Occupation" character varying, "CompanyType" integer, "CompanyActivity" character varying, "ConstitutionDate" timestamp without time zone, "PubliclyExposedPerson" boolean, "CheckPendingTransfers" boolean, "IdentityDocument" character varying, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "Attempts" integer, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "NewAccountId",
        "CompanyId",
        "TaxId",
        "PersonName",
        "PhoneNumber",
        "Mail",
        "Nickname",
        "BirthDate",
        "MotherFullName",
        "FatherFullName",
        "Nationality",
        "BirthCity",
        "BirthState",
        "Gender",
        "Status",
        "MaritalStatus",
        "SpouseName",
        "Occupation",
        "CompanyType",
        "CompanyActivity",
        "ConstitutionDate",
        "PubliclyExposedPerson",
        "CheckPendingTransfers",
        "IdentityDocument",
        "Bank",
        "BankBranch",
        "BankAccount",
        "BankAccountDigit",
        "Attempts",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."NewAccount"
WHERE "NewAccountId" = "paramNewAccountId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getnewaccountbyid(bigint)
    OWNER TO "OSB";
