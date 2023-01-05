DROP FUNCTION public.insertbindcard(bigint, bigint, bigint, bigint, bigint, character varying, integer, bigint);

CREATE OR REPLACE FUNCTION public.insertbindcard(
	"paramAccountId" bigint,
	"paramOperationId" bigint,
	"paramCardOwnerId" bigint,
	"paramCardHolderId" bigint,
	"paramCardHolderContactId" bigint,
	"paramIdentifierCard" character varying,
	"paramUsageType" integer,	
	"paramUserId" bigint	
	)
    RETURNS TABLE ("BindCardId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."BindCard"
	(
	"AccountId",
	"OperationId",
	"CardOwnerId",
	"CardHolderId",
	"CardHolderContactId",	
	"IdentifierCard",
	"UsageType",
	"CreationDate",    
    "UpdateDate",
	"CreationUserId",
	"UpdateUserId"
	)
	VALUES
	(
	"paramAccountId",
	"paramOperationId",
	"paramCardOwnerId",
	"paramCardHolderId",
	"paramCardHolderContactId",	
	"paramIdentifierCard",
	"paramUsageType",
	now(),    
    now(),
	"paramUserId",
	"paramUserId"
	) RETURNING "BindCardId";

$BODY$;

ALTER FUNCTION public.insertbindcard(bigint, bigint, bigint, bigint, bigint, character varying, integer, bigint)
    OWNER TO "OSB";
