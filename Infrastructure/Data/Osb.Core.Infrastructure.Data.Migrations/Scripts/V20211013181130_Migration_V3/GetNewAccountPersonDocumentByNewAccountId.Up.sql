CREATE OR REPLACE FUNCTION public.getnewaccountpersondocumentbynewaccountid(
	"paramNewAccountId" bigint)
    RETURNS TABLE(
    "NewAccountPersonDocumentId" bigint, 
    "NewAccountId" bigint, 
    "NewAccountPersonId" bigint, 
    "DocumentFile" bytea, 
    "DocumentFormat" integer, 
    "DocumentName" character varying, 
    "DocumentType" integer, 
    "Description" character varying, 
    "ExpirationDate" timestamp without time zone, 
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
SELECT  "NewAccountPersonDocumentId",
        "NewAccountId",
        "NewAccountPersonId",
        "DocumentFile",
        "DocumentFormat",
        "DocumentName",
        "DocumentType",
        "Description",
        "ExpirationDate",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."NewAccountPersonDocument"
WHERE "NewAccountId" = "paramNewAccountId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getnewaccountpersondocumentbynewaccountid(bigint)
    OWNER TO "OSB";
