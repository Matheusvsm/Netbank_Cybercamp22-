DROP FUNCTION public.insertunblockcard(character varying, bigint, character varying, character varying, bigint, bigint);

CREATE OR REPLACE FUNCTION public.insertunblockcard(
	"paramIdentifierCard" character varying,
	"paramAccountId" bigint,
	"paramPin" character varying,
	"paramSalt" character varying,	
	"paramUserId" bigint,
	"paramOperationId" bigint)
    RETURNS TABLE ("UnblockCardId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UnblockCard"
    (
    "IdentifierCard",
    "Pin",
    "Salt",    
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
    "paramAccountId",
    0,
    "paramOperationId",
    now(),
    null,
    now(),
    "paramUserId",
    "paramUserId"
    ) RETURNING "UnblockCardId";
$BODY$;

ALTER FUNCTION public.insertunblockcard(character varying, bigint, character varying, character varying, bigint, bigint)
    OWNER TO "OSB";
