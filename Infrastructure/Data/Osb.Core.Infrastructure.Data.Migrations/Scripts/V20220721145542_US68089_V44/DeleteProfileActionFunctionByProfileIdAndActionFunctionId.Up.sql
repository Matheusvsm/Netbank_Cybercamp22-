CREATE FUNCTION public.deleteprofileactionfunctionbyprofileidandactionfunctionid(
	"paramProfileId" bigint,
	"paramActionFunctionId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."ProfileActionFunction"
	SET
			"UpdateDate" = now(),
			"DeletionDate" = now()
	WHERE
			"ProfileId" = "paramProfileId" AND
			"ActionFunctionId" = "paramActionFunctionId"
$BODY$;
ALTER FUNCTION public.deleteprofileactionfunctionbyprofileidandactionfunctionid(bigint, bigint)
    OWNER TO "OSB";