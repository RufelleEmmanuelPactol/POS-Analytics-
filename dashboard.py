import streamlit as st
import pandas as pd
from sqlalchemy import create_engine

# Replace 'your_username', 'your_password', 'your_database_name' with your actual MySQL credentials
# The format of the connection string is 'mysql://username:password@host/database'
connection_string = 'mysql://root:@localhost/kwiksight'

# Replace 'mysql://your_username:your_password@localhost/your_database_name' with your actual MySQL connection string
engine = create_engine('mysql://root:@localhost/kwiksight')

# Example SQL query
#query = "SELECT * ;"

# Replace 'your_table_name' with the actual table name in your MySQL database
#df = pd.read_sql(query, engine)

# Display the DataFrame in a table
#st.dataframe(df)

# Add total sales overview, top selling product, sales over time, etc.
# top selling product
newquery = "SELECT product.productID, product.productName FROM product INNER JOIN purchase ON purchase.productID = product.productID;"
df2 = pd.read_sql(newquery, engine)
st.dataframe(df2)
mostpurchased = "SELECT purchase.orderAmount, purchase.productID FROM purchase ORDER BY purchase.orderAmount DESC LIMIT 10;"
df3 = pd.read_sql(mostpurchased, engine)
st.dataframe(df3)

most_purchased_query = """
SELECT 
    product.productID,
    product.productName,
    purchase.orderAmount
FROM 
    product
INNER JOIN 
    purchase ON purchase.productID = product.productID
ORDER BY 
    purchase.orderAmount DESC
LIMIT 10;
"""

df_most_purchased = pd.read_sql(most_purchased_query, engine)
st.dataframe(df_most_purchased)
import plotly.express as px

fig = px.bar(df_most_purchased, x='productName', y='orderAmount', title='Most Purchased Products')
fig.show()
st.plotly_chart(fig)