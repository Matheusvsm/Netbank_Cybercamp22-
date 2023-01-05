CREATE OR REPLACE FUNCTION public.insertOperationTag(
	"paramOperationId" bigint,
	"paramTag" character varying,
    "paramUserId" bigint
    )
    RETURNS TABLE("OperationTagId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."OperationTag"(
    "OperationId",
    "Tag",
    "CreationDate",
    "UpdateDate",
	"CreationUserId",
	"UpdateUserId"
    )
	VALUES (
		"paramOperationId",
        "paramTag",
        now(),
        now(), 
        "paramUserId",
        "paramUserId"
        ) RETURNING "OperationTagId";	
$BODY$;

ALTER FUNCTION public.insertOperationTag(bigint, character varying, bigint)
    OWNER TO "OSB";