DROP FUNCTION public.insertactivatecard(integer, character varying, bigint, bigint, bigint);

CREATE OR REPLACE FUNCTION public.insertactivatecard(
    "paramStatus" integer,
	"paramIdentifierCard" character varying,
    "paramAccountId" bigint,
	"paramUserId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."ActivateCard"
    (
    "IdentifierCard",
    "AccountId",
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
    "paramStatus",
    now(),
    now(),    
    "paramUserId",
    "paramUserId"
    ) 
RETURNING "ActivateCardId";
$BODY$;

ALTER FUNCTION public.insertactivatecard(integer, character varying, bigint, bigint)
    OWNER TO "OSB";