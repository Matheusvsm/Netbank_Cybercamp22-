DROP FUNCTION public.insertinputlog(character varying, character varying, character varying, character varying, bigint);

CREATE FUNCTION public.insertinputlog(
    "paramBody" character varying,
    "paramMethod" character varying,
    "paramHeaders" character varying,
    "paramUrl" character varying,
    "paramUserId" bigint)
    RETURNS TABLE("InputLogId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

INSERT INTO public."InputLog" (
    "Body",
    "Method",
    "CreationDate",
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId",
    "Headers",
    "Url"
)
VALUES (
    "paramBody",
    "paramMethod",
    Now(),
    Now(),
    "paramUserId",
    "paramUserId",
    "paramHeaders",
    "paramUrl"
)
RETURNING "InputLogId"
$BODY$;

ALTER FUNCTION public.insertinputlog(character varying, character varying, character varying, character varying, bigint)
    OWNER TO "OSB";