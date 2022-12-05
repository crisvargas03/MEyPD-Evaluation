export const Save = async (gradebook) => {
  const url = process.env.REACT_APP_API_URL + "api/gradesBook/save";
  const methodPOST = {
    method: "POST",
    body: JSON.stringify(gradebook),
    headers: {
      "Content-Type": "application/json",
    },
  };

  const resp = await fetch(url, methodPOST);
  const data = await resp.json();

  return await data;
};
