export const GetSubjects = async () => {
  const url = process.env.REACT_APP_API_URL + "api/catalog/Subject";

  const resp = await fetch(url);
  const data = await resp.json();
  return await data;
};
