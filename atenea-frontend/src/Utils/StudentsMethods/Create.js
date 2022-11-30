export const Create = async (student) => {
  const url = process.env.REACT_APP_API_URL + "api/student/create";
  const methodPOST = {
    method: "POST",
    body: JSON.stringify(student),
    headers: {
      "Content-Type": "application/json",
    },
  };

  const resp = await fetch(url, methodPOST);
  const data = await resp.json();

  return await data;
};
