CREATE FUNCTION public.updateprofileactionfunction(
	"paramProfileId" bigint,
	"paramActionFunctionId" bigint,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."ProfileActionFunction"
	SET
			"UpdateDate" = now(),
			"UpdateUserId" = "paramUserId",
			"DeletionDate" = NULL
	WHERE
			"ProfileId" = "paramProfileId" AND
			"ActionFunctionId" = "paramActionFunctionId"
$BODY$;
ALTER FUNCTION public.updateprofileactionfunction(bigint, bigint, bigint)
    OWNER TO "OSB";