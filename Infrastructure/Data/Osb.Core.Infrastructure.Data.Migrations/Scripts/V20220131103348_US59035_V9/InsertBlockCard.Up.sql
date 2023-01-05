DROP FUNCTION public.insertblockcard(character varying, bigint, character varying, character varying, integer, bigint, bigint);

CREATE OR REPLACE FUNCTION public.insertblockcard(
	"paramIdentifierCard" character varying,
	"paramAccountId" bigint,
	"paramPin" character varying,
	"paramSalt" character varying,
	"paramReasonCode" integer,
	"paramUserId" bigint,
	"paramOperationId" bigint)
    RETURNS TABLE ("BlockCardId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."BlockCard"
    (
    "IdentifierCard",
    "Pin",
    "Salt",
    "ReasonCode",
    "AccountId",
    "Status",
    "OperationId",
    "CreationDate",
    "DeletionDate",
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId"    
    )
    VALUES
    (
    "paramIdentifierCard",
    "paramPin",
	"paramSalt",
    "paramReasonCode",
    "paramAccountId",
    0,
    "paramOperationId",
    now(),
    null,
    now(),
    "paramUserId",
    "paramUserId"    
    ) RETURNING "BlockCardId";
$BODY$;

ALTER FUNCTION public.insertblockcard(character varying, bigint, character varying, character varying, integer, bigint, bigint)
    OWNER TO "OSB";
