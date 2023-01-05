CREATE FUNCTION public.getrefundpixinbystatus(
	"paramStatus" integer
    )
    RETURNS TABLE("RefundPixInId" bigint,
                  "AccountId" bigint,
                  "OperationId" bigint,
                  "ToTaxId" character varying,
                  "ToName" character varying,
                  "ToBank" character varying,
                  "ToBankBranch" character varying,
                  "ToBankAccount" character varying,
                  "ToBankAccountDigit" character varying,
                  "RefundValue" decimal,
                  "CustomerMessage" character varying,
                  "DocumentNumber" bigint,
                  "Identifier" character varying,
                  "Status" integer,
                  "Attempts" integer,
                  "ExternalIdentifier" bigint,
                  "CreationDate" timestamp without time zone,
                  "UpdateDate" timestamp without time zone,
                  "DeletionDate" timestamp without time zone,
                  "CreationUserId" bigint,
                  "UpdateUserId" bigint
                  )
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT "RefundPixInId",
        "AccountId",
        "OperationId",
        "ToTaxId",
        "ToName",
        "ToBank",
        "ToBankBranch",
        "ToBankAccount",
        "ToBankAccountDigit",
        "RefundValue",
        "CustomerMessage",
        "DocumentNumber",
        "Identifier",
        "Status",
        "Attempts",
        "ExternalIdentifier",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."RefundPixIn"
WHERE 
    "Status" = "paramStatus"
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getrefundpixinbystatus(integer)
    OWNER TO "OSB";