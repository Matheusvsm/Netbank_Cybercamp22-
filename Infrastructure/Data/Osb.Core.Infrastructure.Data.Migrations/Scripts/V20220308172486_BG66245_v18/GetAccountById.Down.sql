DROP FUNCTION public.getaccountbyid(bigint);

CREATE OR REPLACE FUNCTION public.getaccountbyid(
	    "paramId" bigint)
    RETURNS TABLE(
        "AccountId" bigint,
        "CompanyId" bigint,
        "Name" character varying, 
        "Type" bigint, 
        "Status" bigint,
        "CreationDate" timestamp without time zone, 
        "UpdateDate" timestamp without time zone, 
        "DeletionDate" timestamp without time zone,
        "CreationUserId" bigint, 
        "UpdateUserId" bigint,
        "TaxId" character varying,
        "AccountKey" character varying,
        "SubAccountId" bigint,
        "Bank" character varying, 
        "BankBranch" character varying,
        "BankAccount" character varying, 
        "BankAccountDigit" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  ACC."AccountId",
        ACC."CompanyId",
        ACC."Name",
        ACC."Type",
        ACC."Status",
        ACC."CreationDate",
        ACC."UpdateDate",
        ACC."DeletionDate",
        ACC."CreationUserId",
        ACC."UpdateUserId",
        ACC."TaxId",
        ACC."AccountKey",
        ACC."SubAccountId",
        SACC."Bank",
        SACC."BankBranch",
        SACC."BankAccount",
        SACC."BankAccountDigit"
    FROM
        public."Account" AS ACC
        LEFT JOIN public."SubAccount" AS SACC ON (ACC."SubAccountId" = SACC."SubAccountId")
    WHERE
        (ACC."AccountId" = "paramId")
        AND ACC."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbyid(bigint)
    OWNER TO "OSB";