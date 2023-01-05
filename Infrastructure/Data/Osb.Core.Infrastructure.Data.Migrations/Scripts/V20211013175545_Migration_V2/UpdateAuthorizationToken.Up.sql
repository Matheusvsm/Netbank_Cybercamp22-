CREATE OR REPLACE FUNCTION public.updateauthorizationtoken(
	"paramId" bigint,
	"paramStatus" smallint,
	"paramValidateAttempts" smallint,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."AuthorizationToken"
    
    SET 
        "Status" = "paramStatus",
		"ValidateAttempts" = "paramValidateAttempts",
		"UpdateUserId" = "paramUpdateUserId",
		"UpdateDate" = now()

    WHERE
        "AuthorizationTokenId" = "paramId"
$BODY$;

ALTER FUNCTION public.updateauthorizationtoken(bigint, smallint, smallint, bigint)
    OWNER TO "OSB";