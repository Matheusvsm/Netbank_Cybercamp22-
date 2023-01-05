CREATE OR REPLACE FUNCTION public.insertrememberlogintoken(
	"paramUserId" bigint,
  "paramCompanyId" bigint,
  "paramHashTokenAccess" character varying,
  "paramTokenAccess" character varying)
  RETURNS TABLE("RememberLoginTokenId" bigint)
  LANGUAGE 'sql'
  COST 100
  VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."RememberLoginToken"
(
  "UserId",
  "CompanyId",
  "HashTokenAccess",
  "TokenAccess",
  "CreationDate",
	"UpdateDate",
  "DeletionDate",
  "CreationUserId",
  "UpdateUserId"
)
VALUES
(
  "paramUserId",
  "paramCompanyId",
  "paramHashTokenAccess",
  "paramTokenAccess",
  now(),
  now(),
  null,
  "paramUserId",
  "paramUserId"
)
RETURNING "RememberLoginTokenId"
$BODY$;

ALTER FUNCTION public.insertrememberlogintoken(bigint, bigint, character varying, character varying)
    OWNER TO "OSB";