CREATE OR REPLACE FUNCTION public.insertcancelcard(
    "paramStatus" integer,
	"paramIdentifierCard" character varying,
    "paramAccountId" bigint,
    "paramOperationId" bigint,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."CancelCard"
    (
    "AccountId",
    "OperationId",
    "IdentifierCard",
    "Status",
    "CreationDate",
    "UpdateDate",
    "DeletionDate",
    "CreationUserId",
    "UpdateUserId"
    )
	VALUES
    (
    "paramAccountId",
    "paramOperationId",
    "paramIdentifierCard",
    "paramStatus",
    now(),
    now(),
    null,
    "paramUserId",
    "paramUserId"
    ) 
RETURNING "CancelCardId";
$BODY$;

ALTER FUNCTION public.insertcancelcard(integer, character varying, bigint, bigint, bigint)
    OWNER TO "OSB";