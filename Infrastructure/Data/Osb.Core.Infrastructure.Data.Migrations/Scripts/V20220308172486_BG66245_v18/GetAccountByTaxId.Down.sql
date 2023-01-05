DROP FUNCTION public.getaccountbytaxid(text, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION public.getaccountbytaxid(
        "paramTaxId" text,
        "paramBank" character varying,
        "paramBankBranch" character varying,
        "paramBankAccount" character varying,
        "paramBankAccountDigit" character varying)
        RETURNS TABLE("AccountId" bigint, 
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
SELECT 
               ACC."AccountId",
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
            (ACC."TaxId" = "paramTaxId")
            AND (("paramBank" ISNULL AND SACC."Bank" ISNULL) OR SACC."Bank" = "paramBank")
            AND (("BankBranch" ISNULL AND SACC."BankBranch" ISNULL) OR SACC."BankBranch" = "paramBankBranch")
            AND (("paramBankAccount" ISNULL AND SACC."BankAccount" ISNULL) OR SACC."BankAccount" = "paramBankAccount")
            AND (("paramBankAccountDigit" ISNULL AND SACC."BankAccountDigit" ISNULL) OR SACC."BankAccountDigit" = "paramBankAccountDigit")
AND
    ACC."DeletionDate" IS NULL;
$BODY$; 

ALTER FUNCTION public.getaccountbytaxid(text, character varying, character varying, character varying, character varying)
    OWNER TO "OSB";
