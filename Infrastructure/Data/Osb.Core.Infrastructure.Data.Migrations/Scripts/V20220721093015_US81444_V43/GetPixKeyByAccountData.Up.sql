CREATE OR REPLACE FUNCTION public.getpixkeybyaccountdata(
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramPixKeyValue" character varying,
	"paramPixKeyType" integer)
    RETURNS TABLE("PixKeyId" bigint, "AccountId" bigint, "UserId" bigint, "PixKeyValue" character varying, "PixKeyType" character varying, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 	
    PK."PixKeyId",
    PK."AccountId",
    PK."UserId",
    PK."PixKeyValue",
    PK."PixKeyType",
    PK."CreationDate",
    PK."UpdateDate",
    PK."CreationUserId",
    PK."UpdateUserId"
FROM public."PixKey" AS PK 
INNER JOIN public."SPBAccount" AS SPB ON PK."AccountId" = SPB."AccountId"
WHERE 
    SPB."Bank" = "paramBank"
    AND SPB."BankBranch" = "paramBankBranch"
    AND SPB."BankAccount" = "paramBankAccount"
    AND SPB."BankAccountDigit" = "paramBankAccountDigit"
    AND SPB."DeletionDate" IS NULL
    AND ((PK."PixKeyValue" IS NULL AND "paramPixKeyValue" IS NULL) OR (PK."PixKeyValue" = "paramPixKeyValue"))
    AND PK."PixKeyType" = "paramPixKeyType"
    AND PK."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getpixkeybyaccountdata(character varying, character varying, character varying, character varying, character varying, integer)
    OWNER TO "OSB";