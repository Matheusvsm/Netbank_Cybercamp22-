DROP FUNCTION public.insertoutputlog(bigint, character varying, character varying, bigint);

CREATE FUNCTION public.insertoutputlog(
    "paramResponse" character varying,
    "paramStatusCode" character varying,
    "paramUserId" bigint
)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

INSERT INTO public."OutputLog"(
    "Response",
    "LogDate",
    "CreationDate",
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId",
    "StatusCode"
)

VALUES (
    "paramResponse",
    Now(),
    Now(),
    Now(),
    "paramUserId",
    "paramUserId",
    "paramStatusCode"
)
$BODY$;

ALTER FUNCTION public.insertoutputlog(character varying, character varying, bigint)
    OWNER TO "OSB";