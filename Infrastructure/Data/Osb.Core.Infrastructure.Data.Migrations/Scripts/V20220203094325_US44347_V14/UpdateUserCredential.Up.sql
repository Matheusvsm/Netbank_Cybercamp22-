CREATE OR REPLACE FUNCTION public.updateusercredential(
	"paramUserCredentialId" bigint,
	"paramUpdateUserId" bigint,
	"paramDeletionDate" timestamp without time zone
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."UserCredential"
					SET
					"UpdateDate" = now(),
					"DeletionDate" = "paramDeletionDate",
					"UpdateUserId" = "paramUpdateUserId"
					WHERE
					"UserCredentialId" = "paramUserCredentialId"
$BODY$;

ALTER FUNCTION public.updateusercredential(bigint, bigint, timestamp without time zone)
    OWNER TO "OSB";
