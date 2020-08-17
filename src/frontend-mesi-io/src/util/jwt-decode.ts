export function decodePayload(jwt: string | null): any | null {
  if(jwt) {
    const splits = jwt.split(".");
    if (splits.length !== 3) return null;
  
    const decoded = atob(splits[1]);
    return JSON.parse(decoded);
  }
  
  return null;
}