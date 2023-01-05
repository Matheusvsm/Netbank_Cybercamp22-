CREATE FUNCTION public.deleteprofile(
	"paramProfileId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."Profile"
	SET
			"DeletionDate" = now()
	WHERE
			"ProfileId" = "paramProfileId"
$BODY$;
ALTER FUNCTION public.deleteprofile(bigint)
    OWNER TO "OSB";