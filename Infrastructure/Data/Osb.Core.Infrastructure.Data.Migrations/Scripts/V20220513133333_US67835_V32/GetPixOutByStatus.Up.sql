CREATE FUNCTION public.getpixoutbystatus(
    "paramStatus" integer
    )
    RETURNS TABLE(
                "PixOutId" bigint,
                "AccountId" bigint,
                "OperationId" bigint,
                "ToName" character varying,
                "ToTaxId" character varying,
                "ToBank" character varying,
                "ToBankBranch" character varying,
                "ToBankAccount" character varying,
                "ToBankAccountDigit" character varying,
                "Value" decimal,
                "PaymentDate" timestamp without time zone,
                "Identifier" character varying,
                "CustomerMessage" character varying,
                "PixKey" character varying,
                "PixKeyType" integer,
                "AccountType" integer,
                "Description" character varying,
                "Attempts" integer,
                "Status" integer,
                "ExternalIdentifier" bigint,
                "CreationDate" timestamp without time zone,
                "UpdateDate" timestamp without time zone,
                "CreationUserId" bigint,
                "UpdateUserId" bigint
                )
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT  "PixOutId",
        "AccountId",
        "OperationId",
        "ToName",
        "ToTaxId",
        "ToBank",
        "ToBankBranch",
        "ToBankAccount",
        "ToBankAccountDigit",
        "Value",
        "PaymentDate",
        "Identifier",
        "CustomerMessage",
        "PixKey",
        "PixKeyType",
        "AccountType",
        "Description",
        "Attempts",
        "Status",
        "ExternalIdentifier",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."PixOut"
WHERE 
    "Status" = "paramStatus"
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getpixoutbystatus(integer)
    OWNER TO "OSB";