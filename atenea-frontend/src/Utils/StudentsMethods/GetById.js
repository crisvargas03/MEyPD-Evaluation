export const GetById = async (Id) => {
  const url = process.env.REACT_APP_API_URL + `api/Student/${Id}`;

  const resp = await fetch(url);
  const data = await resp.json();
  return await data;
};
