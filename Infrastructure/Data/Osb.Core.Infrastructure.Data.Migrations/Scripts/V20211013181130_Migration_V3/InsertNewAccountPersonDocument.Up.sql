CREATE OR REPLACE FUNCTION public.insertnewaccountpersondocument(
	"paramNewAccountId" bigint,
	"paramNewAccountPersonId" bigint,
	"paramDocumentFile" bytea,
	"paramDocumentFormat" integer,
	"paramDocumentName" character varying,
	"paramDocumentType" integer,
	"paramDescription" character varying,
	"paramExpirationDate" timestamp without time zone,
    "paramUserId" bigint)
    RETURNS TABLE("NewAccountPersonDocumentId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."NewAccountPersonDocument"
                    (
                    "NewAccountId",
                    "NewAccountPersonId",
                    "DocumentFile",
                    "DocumentFormat",
                    "DocumentName",
                    "DocumentType" ,
                    "Description",
                    "ExpirationDate",
                    "CreationDate",
                    "UpdateDate",
                    "DeletionDate",
                    "CreationUserId",
                    "UpdateUserId"
                    )
	VALUES (
            "paramNewAccountId",
            "paramNewAccountPersonId",
            "paramDocumentFile",
            "paramDocumentFormat",
            "paramDocumentName",
            "paramDocumentType" ,
            "paramDescription",
            "paramExpirationDate",
            NOW(),
            NOW(),
            NULL,
            "paramUserId",
            "paramUserId"
           ) RETURNING "NewAccountPersonDocumentId";
$BODY$;

ALTER FUNCTION public.insertnewaccountpersondocument(bigint, bigint, bytea, integer, character varying, integer, character varying, timestamp without time zone, bigint)
    OWNER TO "OSB";