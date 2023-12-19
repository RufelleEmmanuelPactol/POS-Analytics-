import streamlit as st
import pandas as pd
from sqlalchemy import create_engine
import plotly.express as px
from sklearn.tree import DecisionTreeClassifier, export_text
from sklearn.model_selection import train_test_split
from sklearn import metrics
import matplotlib.pyplot as plt
from sklearn.tree import plot_tree

st.set_page_config(
    layout="wide",
    initial_sidebar_state="expanded",
)

# Replace 'your_username', 'your_password', 'your_database_name' with your actual MySQL credentials
# The format of the connection string is 'mysql://username:password@host/database'
connection_string = 'mysql://root:@localhost/kwiksight'

# Replace 'mysql://your_username:your_password@localhost/your_database_name' with your actual MySQL connection string
engine = create_engine('mysql://root:@localhost/kwiksight')

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
#st.dataframe(df_most_purchased)
fig = px.bar(df_most_purchased, x='productName', y='orderAmount', title='Most Purchased Products')
fig.update_layout(title='Most Ordered Products', xaxis_title='Product name', yaxis_title='Number of times purchased', plot_bgcolor='white')



total_sales_query = """
SELECT 
    product.productID,
    product.productName,
    SUM(purchase.orderAmount) AS totalSales
FROM 
    product
LEFT JOIN 
    purchase ON purchase.productID = product.productID
GROUP BY 
    product.productID, product.productName
ORDER BY 
    totalSales DESC
    LIMIT 10;
"""

df_total_sales = pd.read_sql(total_sales_query, engine)
#st.dataframe(df_total_sales)
totalprodsales = px.bar(df_total_sales, x='productName', y='totalSales', title='Total Sales Overview')
totalprodsales.update_layout(title='Most Sold Products', xaxis_title='Product name', yaxis_title='Total Sales', plot_bgcolor='white')

sales_over_time_query = """
SELECT 
    DATE(purchase.orderEvent) AS purchaseDate,
    SUM(purchase.orderAmount) AS totalSales
FROM 
    purchase
WHERE
    DATE(purchase.orderEvent) <= '2023-03-31'
GROUP BY 
    DATE(purchase.orderEvent)
ORDER BY 
    DATE(purchase.orderEvent);
"""

df_sales_over_time = pd.read_sql(sales_over_time_query, engine)
#st.dataframe(df_sales_over_time)
sales_over_time = px.line(df_sales_over_time, x='purchaseDate', y='totalSales', title='Sales Over Time')
sales_over_time.update_layout(title='Sales Over Time', xaxis_title='Date', yaxis_title='Total Sales', plot_bgcolor='white')


st.title("💰 | Sales Dashboard")
st.markdown("##")

left_column, middle_column, right_column = st.columns(3)
mostboughtprod = df_total_sales['productName'].iloc[0]
totalsales = int(df_total_sales['totalSales'].sum())
with left_column:
    st.subheader("Total Sales: ")
    st.subheader(f"US $ {totalsales:,}")
with middle_column:
    st.subheader("Most Bought Product: ")
    st.subheader(f"{mostboughtprod}")    


left_column, right_column = st.columns(2)
left_column.plotly_chart(fig, use_container_width=True)
right_column.plotly_chart(totalprodsales, use_container_width=True)

left_column, middle_column, right_column = st.columns(3)
middle_column.plotly_chart(sales_over_time, use_container_width=True)


