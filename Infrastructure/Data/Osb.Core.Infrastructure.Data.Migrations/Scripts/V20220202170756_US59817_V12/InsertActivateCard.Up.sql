DROP FUNCTION public.insertactivatecard(integer, character varying, bigint, bigint);

CREATE OR REPLACE FUNCTION public.insertactivatecard(
    "paramStatus" integer,
	"paramIdentifierCard" character varying,
    "paramAccountId" bigint,
    "paramOperationId" bigint,
	"paramUserId" bigint
    )
    RETURNS TABLE ("ActivateCardId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."ActivateCard"
    (
    "IdentifierCard",
    "AccountId",
    "OperationId",
    "Status",
    "CreationDate",
    "UpdateDate",    
    "CreationUserId",
    "UpdateUserId"
    )
	VALUES
    (
    "paramIdentifierCard",
    "paramAccountId",
    "paramOperationId",
    "paramStatus",
    now(),
    now(),    
    "paramUserId",
    "paramUserId"
    ) RETURNING "ActivateCardId";
$BODY$;

ALTER FUNCTION public.insertactivatecard(integer, character varying, bigint, bigint, bigint)
    OWNER TO "OSB";